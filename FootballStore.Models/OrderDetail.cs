using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [ValidateNever]
        public Order order { get; set; }
        [Required]
        public int ProductId { get; set; }
        [ValidateNever]
        public Product product { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
