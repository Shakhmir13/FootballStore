using FootballStore.DataAccess.Data;
using FootballStore.DataAccess.Repository.Interfaces;
using FootballStore.Models;

namespace FootballStore.DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>
    {
        private ApplicationDbContext _context;
        public OrderDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
