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
    /// <typeparam name="T"></typeparam>
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public T GetById(int id) => _dbSet.Find(id);
        public IReadOnlyCollection<T> GetAll()
        {
            return _dbSet.OrderBy(item => item.Id).ToImmutableList<T>();
        }
        public void Add(T item) => _dbSet.Add(item);

        public void Save() => _dbContext.SaveChanges();

        public void Remove(T item) => _dbSet.Remove(item);
    }
}
