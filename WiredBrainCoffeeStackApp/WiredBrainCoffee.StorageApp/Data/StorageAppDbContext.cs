using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WiredBrainCoffee.StorageApp.Constants;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Data;

public class StorageAppDbContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Organization> Organizations => Set<Organization>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        var configuration = builder.Build();

        optionsBuilder.UseInMemoryDatabase("StorageAppDb");
    }
}
