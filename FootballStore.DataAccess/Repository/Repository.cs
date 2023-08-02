using FootballStore.DataAccess.Data;
using FootballStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FootballStore.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _context.Products.Include(x => x.Category);
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entitiy)
        {
            _dbSet.RemoveRange(entitiy);
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.ToList();
        }
        public T GetT(Expression<Func<T, bool>> predicate, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(predicate);
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault();
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
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
