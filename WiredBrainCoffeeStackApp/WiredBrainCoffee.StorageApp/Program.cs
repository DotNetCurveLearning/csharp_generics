using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());

AddEmployees(employeeRepository);
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
static void AddOrganizations(IRepository<Organization> organizationRepository)
{
    organizationRepository.Add(new Organization { Name = "Pluralsight" });
    organizationRepository.Add(new Organization { Name = "Globomantics" });

    organizationRepository.Save();
}

void WriteAllOrganizationsToConsole(IReadOnlyCollection<Organization> organizations)
{
    foreach (var organization in organizations)
    {
        Console.WriteLine($"Organization: {organization}");
    }
}

static void AddEmployees(IRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = "Julia" });
    employeeRepository.Add(new Employee { FirstName = "Anna" });
    employeeRepository.Add(new Employee { FirstName = "Thomas" });

    employeeRepository.Save();
}