using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

var employeeRepository = new GenericRepository<Employee>();
var organizationRepository = new GenericRepository<Organization>();

AddEmployees(employeeRepository);
Console.WriteLine($"Employee: {GetEmployeeById(employeeRepository).FirstName}");

Console.WriteLine();

AddOrganizations(organizationRepository);

Console.ReadLine();

Employee GetEmployeeById(GenericRepository<Employee> employeeRepository)
{
    return employeeRepository.GetById(2);
}
static void AddOrganizations(GenericRepository<Organization> organizationRepository)
{
    organizationRepository.Add(new Organization { Name = "Pluralsight" });
    organizationRepository.Add(new Organization { Name = "Globomantics" });

    organizationRepository.Save();
}

static void AddEmployees(GenericRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = "Julia" });
    employeeRepository.Add(new Employee { FirstName = "Anna" });
    employeeRepository.Add(new Employee { FirstName = "Thomas" });

    employeeRepository.Save();
}