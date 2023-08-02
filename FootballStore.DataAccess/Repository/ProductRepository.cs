using FootballStore.DataAccess.Data;
using FootballStore.Models;

namespace FootballStore.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
