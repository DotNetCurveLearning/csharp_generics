using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());

AddEmployees(employeeRepository);
AddManagers(employeeRepository);
Console.WriteLine($"Employee: {GetEmployeeById(employeeRepository).FirstName}");
WriteAllToConsole(employeeRepository);

Console.WriteLine();

var organizationRepository = new ListRepository<Organization>();
AddOrganizations(organizationRepository);
WriteAllToConsole(organizationRepository);

Console.ReadLine();

void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();

    foreach (var item in items)
    {
        Console.WriteLine($"Employee: {item}");
    }
}

Employee GetEmployeeById(IRepository<Employee> employeeRepository)
{
    return employeeRepository.GetById(2);
}
static void AddOrganizations(IWriteRepository<Organization> repo)
{
    repo.Add(new Organization { Name = "Pluralsight" });
    repo.Add(new Organization { Name = "Globomantics" });

    repo.Save();
}
static void AddEmployees(IWriteRepository<Employee> repo)
{
    repo.Add(new Employee { FirstName = "Julia" });
    repo.Add(new Employee { FirstName = "Anna" });
    repo.Add(new Employee { FirstName = "Thomas" });
    
    repo.Save();
}

void AddManagers(IWriteRepository<Manager> managerRepository)
{
    managerRepository.Add(new Manager { FirstName = "Sara" });
    managerRepository.Add(new Manager { FirstName = "Henry" });

    managerRepository.Save();
}