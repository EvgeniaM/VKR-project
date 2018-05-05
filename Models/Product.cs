
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ServerVKR.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Price { get; set; }
        public Category Category { get; set; }

        [NotMapped]
        public bool NewItem { get; set; }
        [NotMapped]
        public List<Category> Categories { get; set;}
        [NotMapped]
        public Guid IdForCategory { get; set; }
    }
}