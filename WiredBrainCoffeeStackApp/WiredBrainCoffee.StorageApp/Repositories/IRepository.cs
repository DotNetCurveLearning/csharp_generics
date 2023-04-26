using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories;

public interface IReadRepository<out T>
{
    T GetById(int id);
    IReadOnlyCollection<T> GetAll();
}

public interface IWriteRepository<in T>
{
    void Add(T item);
    void Remove(T item);
    void Save();
}
public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : IEntity
{}