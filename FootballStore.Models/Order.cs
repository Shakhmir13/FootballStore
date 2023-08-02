using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FootballStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        public DateTime DateOfOrder { get; set; }
        public double Total { get; set; }
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string City { get; set; }


    }
}
