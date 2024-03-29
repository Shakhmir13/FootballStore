﻿using FootballStore.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FootballStore.DataAccess.ViewModels
{
    public class CartVM
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ValidateNever]
        public Product Product { get; set; }
        [ValidateNever]
        public string ApplicationUserId { get; set; }
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        [ValidateNever]
        public int Count { get; set; }

        public IEnumerable<Cart> ListOfCart { get; set; } = new List<Cart>();
        public Order Order { get; set; }
    }
}
