using FootballStore.Models;

namespace FootballStore.DataAccess.ViewModels
{
    public class CategoryVM
    {
        public Category category { get; set; } = new Category();
        public IEnumerable<Category> categories { get; set; } = new List<Category>();
    }
}
