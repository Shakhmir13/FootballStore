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
        public void IncrementCartItem(Cart cartItem, int count)
        {
            var cartDB = _context.Carts.FirstOrDefault(x => x.Id == cartItem.Id);
            if (cartDB != null)
            {
                cartDB.Count += count;
            }
        }
        public void DecrementalCartItem(Cart cartItem, int count)
        {
            var cartDB = _context.Carts.FirstOrDefault(x => x.Id == cartItem.Id);
            if (cartDB != null)
            {
                cartDB.Count -= count;
            }
        }

    }
}
