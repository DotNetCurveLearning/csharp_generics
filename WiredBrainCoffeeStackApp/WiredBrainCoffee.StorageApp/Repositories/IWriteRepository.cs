namespace WiredBrainCoffee.StorageApp.Repositories;

// The type can be more specific than the interface (a contravariant type)
public interface IWriteRepository<in T>
{
    void Add(T item);
    void Remove(T item);
    void Save();
}
