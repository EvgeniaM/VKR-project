using System;
using System.Threading.Tasks;
using ServerVKR.Data;
using ServerVKR.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ServerVKR.Services {
    public class ReviewsService {
        private readonly ApplicationDbContext _db;

        public ReviewsService(ApplicationDbContext db) {
            _db = db;
        }

        public List<Review> GetReviews() {
            var reviews = _db.Reviews;

            return reviews.OrderByDescending(r => r.Date).ToList();
        }
        
        //получаем товар на вход, добавляем в бд и сохраняем
        public void AddReview(Review model) {
            var review = new Review {
                ClientName = model.ClientName,
                Text = model.Text,
                Date = DateTime.Now
            };  

           _db.Reviews.Add(review);
           _db.SaveChanges();            
        }
        public void RemoveReview(Guid? id) {
            var review = _db.Reviews.SingleOrDefault(r => r.Id == id);

            _db.Reviews.Remove(review);
            _db.SaveChanges();
        }
    }
}