using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ServerVKR.Models
{
    public class Review
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ClientName { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        [NotMapped]
        public bool NewItem { get; set; }
    }
}