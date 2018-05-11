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

        public List<Order> GetOrders() {
            var orders = _db.Orders.Include(o => o.OrderItems);
            
            return orders.ToList();
        }
        
        public Order GetOrder(Guid? id) {
           var order = _db.Orders.Include(o => o.OrderItems).SingleOrDefault(o => o.Id == id);
            
           return order;
        }
        //получаем товар на вход, добавляем в бд и сохраняем
        public void AddOrder(Order model) {
           _db.Orders.Add(model);
           _db.SaveChanges();            
        }
        //удаляем товар
        public void RemoveOrder(Guid? id) {
            var order = _db.Orders.SingleOrDefault(o => o.Id == id);

            _db.Orders.Remove(order);
            _db.SaveChanges();
        }
    }
}