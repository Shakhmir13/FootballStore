using FootballStore.DataAccess.Data;
using FootballStore.Models;

namespace FootballStore.DataAccess.Repository
{
    public class OrderRepository : Repository<Order>
    {
        private ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
