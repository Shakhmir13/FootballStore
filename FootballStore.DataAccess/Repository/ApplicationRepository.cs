using FootballStore.DataAccess.Data;
using FootballStore.Models;

namespace FootballStore.DataAccess.Repository
{
    public class ApplicationRepository : Repository<ApplicationUser>
    {
        private ApplicationDbContext _context;
        public ApplicationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
