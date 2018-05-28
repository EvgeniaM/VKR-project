using System;
using System.Threading.Tasks;
using ServerVKR.Data;
using ServerVKR.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ServerVKR.Services {
    public class OrdersService {
        private readonly ApplicationDbContext _db;

        public OrdersService(ApplicationDbContext db) {
            _db = db;
        }
        //список заказов
        public List<Order> GetOrders() {
            var orders = _db.Orders.Include(o => o.OrderItems);
            
            return orders.OrderBy(o => o.Number).ToList();
        }
        //получаем один заказ
        public Order GetOrder(Guid? id) {
           var order = _db.Orders.Include(o => o.OrderItems).ThenInclude(i => i.Product).SingleOrDefault(o => o.Id == id);
            
           return order;
        }
        //добавляем заказ
        public void AddOrder(Order model) {
            var order = new Order {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                Address = model.Address,
                Comment = model.Comment,
                CreatedDate = DateTime.Now,
                Status = "Создан",
                Number = _db.Orders.ToList().Count+1,
            };  
            
            //добавляем позиции в заказ
            order.OrderItems = new List<OrderItem>();
            order.TotalPtice = 0;
            foreach (var item in model.OrderItems) {
                var product = _db.Products.SingleOrDefault(p => p.Id == item.Product.Id);
                var orderItem = new OrderItem {
                    Product = product,
                    Quantity = item.Quantity,
                    Price = item.Price
                };
                order.TotalPtice += orderItem.Price*orderItem.Quantity;
                order.OrderItems.Add(orderItem);
            }
                                    
           _db.Orders.Add(order);
           _db.SaveChanges();            
        }
        public void EditOrder(Order model) {
            
            var order = _db.Orders.Include(o => o.OrderItems).ThenInclude(i => i.Product).SingleOrDefault(o => o.Id == model.Id);
            
            order.FirstName = model.FirstName;
            order.LastName = model.LastName;
            order.Comment = model.Comment;
            order.Phone = model.Phone;
            order.Address = model.Address;
            order.CreatedDate = model.CreatedDate;
            order.Status = model.Status;
           _db.SaveChanges();            
        }
        //удаляем заказ
        public void RemoveOrder(Guid? id) {
            var order = _db.Orders.Include(o => o.OrderItems).SingleOrDefault(o => o.Id == id);

            foreach (var item in order.OrderItems) {
                _db.OrderItems.Remove(item);
            }
            _db.SaveChanges();

            _db.Orders.Remove(order);
            _db.SaveChanges();
        }
    }
}