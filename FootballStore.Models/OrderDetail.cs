using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

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
