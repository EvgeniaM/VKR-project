using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ServerVKR.Models
{
    public class ReviewsViewModel
    {
        public List<Review> Reviews { get; set; }
        public Review Review { get; set; }
    }
}