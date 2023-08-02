using FootballStore.DataAccess.Data;
using FootballStore.DataAccess.Repository.Interfaces;

namespace FootballStore.DataAccess.Repository
{
    public class ActionUnit : IActionUnit
    {
        private ApplicationDbContext _context;
        public CategoryRepository Category { get; private set; }
        public ProductRepository Product { get; private set; }
        public CartRepository Cart { get; private set; }
        public ApplicationRepository ApplicationUser { get; private set; }
        public OrderRepository Order { get; private set; }
        public OrderDetailRepository OrderDetail { get; private set; }
        public ActionUnit(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(context);
            Product = new ProductRepository(context);
            Cart = new CartRepository(context);
            ApplicationUser = new ApplicationRepository(context);
            OrderDetail = new OrderDetailRepository(context);
            Order = new OrderRepository(context);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
