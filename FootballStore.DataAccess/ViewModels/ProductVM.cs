using FootballStore.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FootballStore.DataAccess.ViewModels
{
    public class ProductVM
    {
        public Product product { get; set; } = new Product();
        [ValidateNever]
        public IEnumerable<Product> products { get; set; } = new List<Product>();
        [ValidateNever]
        public IEnumerable<SelectListItem> Categories { get; set; }
        //public IEnumerable<Category> CategoryList { get; set; }

    }
}
