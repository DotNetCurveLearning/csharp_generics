﻿using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());

AddEmployees(employeeRepository);
AddManagers(employeeRepository);
//Console.WriteLine($"Employee: {GetEmployeeById(employeeRepository).FirstName}");
WriteAllToConsole(employeeRepository);

//Console.WriteLine();

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

    AddBatch(repo, organizations);
}

static void AddBatch<T>(IWriteRepository<T> repo, T[] items)
{
    foreach (var item in items)
    {
        repo.Add(item);
    }
    
    repo.Save();
}

static void AddEmployees(IRepository<Employee> repo)
{
    var employees = new[]
    {
        new Employee { FirstName = "Julia" },
        new Employee { FirstName = "Anna" },
        new Employee { FirstName = "Thomas" }
    };

    AddBatch(repo, employees);
}

void AddManagers(IWriteRepository<Manager> managerRepository)
{
    managerRepository.Add(new Manager { FirstName = "Sara" });
    managerRepository.Add(new Manager { FirstName = "Henry" });

    managerRepository.Save();
}