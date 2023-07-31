using FootballStore.DataAccess.Data;
using FootballStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.DataAccess.Repository
{
    internal class ApplicationRepository : Repository<ApplicationUser>, IApplicationUser
    {
        private ApplicationDbContext _context;
        public ApplicationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(ApplicationUser applicationUser)
        {
            var userDB = _context.ApplicationUsers.FirstOrDefault(x => x.Id == applicationUser.Id);
            if (userDB != null)
            {
                userDB.Name = applicationUser.Name;
                userDB.Address = applicationUser.Address;
                userDB.City = applicationUser.City;
                userDB.Mail = applicationUser.Mail;
            }
        }
    }
}
