namespace FootballStore.DataAccess.Repository.Interfaces
{
    public interface IActionUnit
    {
        CategoryRepository Category { get; }
        ProductRepository Product { get; }
        CartRepository Cart { get; }
        ApplicationRepository ApplicationUser { get; }
        OrderRepository Order { get; }
        OrderDetailRepository OrderDetail { get; }
        void Save();
    }
}
