using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories;
public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> 
    where T : IEntity
{}