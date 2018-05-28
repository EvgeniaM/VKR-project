using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ServerVKR.Models
{
    public class Delivery
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Price { get; set; }

        [NotMapped]
        public bool NewItem { get; set; }
    }
}