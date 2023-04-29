namespace WiredBrainCoffee.StorageApp.Repositories;

// The type can be less specific than the interface
public interface IReadRepository<out T>
{
    T GetById(int id);
    IReadOnlyCollection<T> GetAll();
}
