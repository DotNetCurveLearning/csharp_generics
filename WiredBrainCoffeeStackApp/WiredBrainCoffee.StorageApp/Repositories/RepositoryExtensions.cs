namespace WiredBrainCoffee.StorageApp.Repositories;

public static class RepositoryExtensions
{
    public static void AddBatch<T>(this IWriteRepository<T> repo, T[] items)
    {
        foreach (var item in items)
        {
            repo.Add(item);
        }

        repo.Save();
    }
}
