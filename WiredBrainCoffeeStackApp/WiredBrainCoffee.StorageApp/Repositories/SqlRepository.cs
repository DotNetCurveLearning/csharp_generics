using WiredBrainCoffee.StorageApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Immutable;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    /// <summary>
    /// This class uses EF Core 6 to store the data
    /// in an in-memory database.
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public class SqlRepository<TItem> : IRepository<TItem> where TItem : class, IEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TItem> _dbSet;

        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TItem>();
        }

        public TItem GetById(int id) => _dbSet.Find(id);
        public IReadOnlyCollection<TItem> GetAll()
        {
            return _dbSet.ToImmutableList<TItem>();
        }
        public void Add(TItem item) => _dbSet.Add(item);

        public void Save() => _dbContext.SaveChanges();

        public void Remove(TItem item) => _dbSet.Remove(item);
    }
}
