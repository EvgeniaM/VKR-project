using System;
using System.Threading.Tasks;
using ServerVKR.Data;
using ServerVKR.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ServerVKR.Services {
    public class DeliveryService {
        private readonly ApplicationDbContext _db;

        public DeliveryService(ApplicationDbContext db) {
            _db = db;
        }

        public List<Delivery> GetDeliveryMethods() {
            var methods = _db.Deliverys;
            
            return methods.ToList();
        }

        public Delivery GetDeliveryMethod(Guid? id) {
           var method = _db.Deliverys.SingleOrDefault(d => d.Id == id);
            
           return method;
        }

        public void AddMethod(Delivery model) {
           _db.Deliverys.Add(model);
           _db.SaveChanges();            
        }

        public void EditMethod(Delivery model) {
            var method = _db.Deliverys.SingleOrDefault(d => d.Id == model.Id);

            method.Name = model.Name;
            method.Price = model.Price;

           _db.SaveChanges();            
        }

        public void RemoveMethod(Guid? id) {
            var method = _db.Deliverys.SingleOrDefault(d => d.Id == id);
            
            _db.Deliverys.Remove(method);
            _db.SaveChanges();
        }
    }
}