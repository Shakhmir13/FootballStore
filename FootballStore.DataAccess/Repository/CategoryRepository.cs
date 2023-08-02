using FootballStore.DataAccess.Data;
using FootballStore.Models;

namespace FootballStore.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>
    {
        private ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
