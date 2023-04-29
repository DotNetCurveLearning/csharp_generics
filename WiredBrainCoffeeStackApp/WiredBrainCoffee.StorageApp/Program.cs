using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());

AddEmployees(employeeRepository);
AddManagers(employeeRepository);
//Console.WriteLine($"Employee: {GetEmployeeById(employeeRepository).FirstName}");
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
        Console.WriteLine($"{item}");
    }
}

Employee GetEmployeeById(IRepository<Employee> employeeRepository)
{
    return employeeRepository.GetById(2);
}
static void AddOrganizations(IRepository<Organization> repo)
{
    var organizations = new[]
    {
        new Organization { Name = "Pluralsight" },
        new Organization { Name = "Globomantics" }
    };

    repo.AddBatch(organizations);
}

static void AddEmployees(IRepository<Employee> repo)
{
    var employees = new[]
    {
        new Employee { FirstName = "Julia" },
        new Employee { FirstName = "Anna" },
        new Employee { FirstName = "Thomas" }
    };

    repo.AddBatch(employees);
}

void AddManagers(IWriteRepository<Manager> managerRepository)
{
    var saraManager = new Manager { FirstName = "Sara" };
    var saraManagerCopy = saraManager.Copy();

    managerRepository.Add(saraManager);

    if (saraManagerCopy is not null)
    {
        saraManagerCopy.FirstName += "_Copy";
        managerRepository.Add(saraManagerCopy);
    }

    managerRepository.Add(new Manager { FirstName = "Henry" });

    managerRepository.Save();
}