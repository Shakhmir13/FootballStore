using FootballStore.Models;

namespace FootballStore.DataAccess.Repository.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        void IncrementCartItem(Cart cartItem, int count);
        void DecrementalCartItem(Cart cartItem, int count);

    }
}
