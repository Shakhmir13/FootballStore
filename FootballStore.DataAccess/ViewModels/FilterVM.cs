using FootballStore.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FootballStore.DataAccess.ViewModels
{
    public class FilterVM
    {
        public Product product { get; set; } = new Product();
        [ValidateNever]
        public IEnumerable<Product> products { get; set; } = new List<Product>();
        [ValidateNever]
        public IEnumerable<Category> Categories { get; set; }

    }
}
