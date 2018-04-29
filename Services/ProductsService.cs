using System;
using System.Threading.Tasks;
using ServerVKR.Data;
using ServerVKR.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServerVKR.Services {
    public class ProductsService {
        private readonly ApplicationDbContext _db;

        public ProductsService(ApplicationDbContext db) {
            _db = db;
        }

        public List<Product> GetProducts() {
            var products = _db.Products;
            
            return products.ToList();
        }
        //получаем товар по айди
        public Product GetProduct(Guid? id) {
            var product = _db.Products.SingleOrDefault(p => p.Id == id);
            
            return product;
        }
        //получаем товар на вход, добавляем в бд и сохраняем
        public void AddProduct(Product model) {
           _db.Products.Add(model);
           _db.SaveChanges();            
        }
        //получаем товар на вход, изменяем имя и цену, сохраняем
        public void EditProduct(Product model) {
            var product = _db.Products.SingleOrDefault(p => p.Id == model.Id);

            product.Name = model.Name;
            product.Price = model.Price;

           _db.SaveChanges();            
        }
        //удаляем товар
        public void RemoveProduct(Guid? id) {
            var product = _db.Products.SingleOrDefault(p => p.Id == id);

            _db.Products.Remove(product);
            _db.SaveChanges();
        }
    }
}