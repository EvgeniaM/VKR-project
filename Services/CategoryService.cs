using System;
using System.Threading.Tasks;
using ServerVKR.Data;
using ServerVKR.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServerVKR.Services {
    public class CategoryService {
        private readonly ApplicationDbContext _db;

        public CategoryService(ApplicationDbContext db) {
            _db = db;
        }

        public List<Category> GetCategories() {
            var category = _db.Categories;
            
            return category.ToList();
        }

        public Category GetCategory(Guid? id) {
           var category = _db.Categories.SingleOrDefault(p => p.Id == id);
            
           return category;
        }
        //получаем товар на вход, добавляем в бд и сохраняем
        public void AddCategory(Category model) {
           _db.Categories.Add(model);
           _db.SaveChanges();            
        }
        //получаем товар на вход, изменяем имя и цену, сохраняем
        public void EditCategory(Category model) {
            var category = _db.Categories.SingleOrDefault(p => p.Id == model.Id);

            category.Name = model.Name;

           _db.SaveChanges();            
        }
        //удаляем товар
        public void RemoveCategory(Guid? id) {
            var category = _db.Categories.SingleOrDefault(p => p.Id == id);

            _db.Categories.Remove(category);
            _db.SaveChanges();
        }
    }
}