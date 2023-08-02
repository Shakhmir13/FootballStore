using FootballStore.DataAccess.Data;
using FootballStore.DataAccess.Repository.Interfaces;
using FootballStore.Models;

namespace FootballStore.DataAccess.Repository
{
    public class CartRepository : Repository<Cart>
    {
        private ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
