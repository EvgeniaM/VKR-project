
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ServerVKR.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Comment { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public Delivery Deliverys { get; set; }
        public int TotalPtice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Status { get; set; }
        public int Number { get; set; }
        
    }
}