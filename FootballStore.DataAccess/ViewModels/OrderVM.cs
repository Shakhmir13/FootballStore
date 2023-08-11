using FootballStore.Models;

namespace FootballStore.DataAccess.ViewModels
{
    public class OrderVM
    {
        public IEnumerable<Order> orders { get; set; } = new List<Order>();
    }
}
