# Implementing Generic Classes

## Using multiple type parameters

```
    public class GenericRepository<TItem,TKey>
    {
        public TKey? Key { get; set; }        
        protected readonly List<TItem> _items = new();
        public void Add(TItem item)
        {
            _items.Add(item);
        }

        public void Save()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class GenericRepositoryWithRemove<TItem,TKey> : GenericRepository<TItem, TKey>
    {
        public void Remove(T item)
        {
            _items.Remove(item);
        }
    }
```

In a subclass, we can also define less or more generic type parameters than in a base class.

We can pass concrete types to the base class. In this case, in the sublcass we don't have to specify that parameter:

```
    public class GenericRepositoryWithRemove<TItem> : GenericRepository<TItem, string>
```

## Add a generic type constraint

We define such a type constraint after the class name with the keyword **where** and the same syntax used with inheritance:

```
public class GenericRepository<TItem> where TItem : EntityBase
```

## Work with class constraint

By using Generic Constraints in C#, we can specify what type of placeholder the generic class can accept. If we try to 
instantiate a generic class with the placeholder type, that is not allowed by a constraint, then the compiler will throw a 
compile-time error. 

The order works like normal inheritance in C#: 

1) class or struct
2) Then all the interfaces that we need on our generic type parameter.
3) At the end, we can define the new() constraint.

he following are the list of different type of generic constraints available in C#:

**where T: struct** => The type argument must be non-nullable value types such as primitive data types int, double, char, 
                       bool, float, etc. The struct constraint can’t be combined with the unmanaged constraint.

**where T: class** => The type argument must be a reference type. This constraint can be applied to any class (non-nullable), 
                      interface, delegate, or array type in C#.

**where T: new()** => The type argument must be a reference type that has a public parameterless (default) constructor.
                      **The type cannot be abstract**. In a constraint chain, **it must be the last one**.

**where T: <base class name>** => The type of argument must be or derive from the specified base class.

**where T: <interface name>** => The type argument must be or implement the specified interface. Also, multiple interface 
                                 constraints can be specified.

**where T: U** => The type argument supplied for must be or derive from the argument supplied for U. In a nullable context, 
                  if U is a non-nullable reference type, T must be a non-nullable reference type. If U is a nullable reference 
                  type, T may be either nullable or non-nullable.

**IMPORTANT**

When we have multiple type parameters, then we can define multiple **where** for the different type parameters:

```
public class GenericRepository<TItem,TKey> 
    where TItem : class, IEntity
    where TKey : struct
```

# Working with generic interfaces

The use of generic interfaces is based on the **Dependency Inversion Control**, that stablish that a component **must depend on 
abstractions**, and not in implementations.

## Understand covariance

Generic parameters of interfaces are by default, invariant. This means they have to have exactly **the same type as the type that we use on the class that implements the interface**.
It means that if we have:

```
IRepository<Organization> repo = new ListRepository<Organization>();
```

We have on the interface **exactly** the same type argument as on the class. This works as the ListRepository of Organization is an IRepository of Organization. But the generic type of this generic IRepository
interface is, by default, **invariant**.
This means, on the interface, we cannot use a **less specific type argument** like, for example, the IEntity type.
For methods where we pass in an item, it's not okay to pass in an IEntity because the ListRepository needs, actually, an Organization. 

This means, for the methods where we read from the repository, we could have **a less specific type**, and this is what **covariance** is about.

## Understand contravariance

## Work with interface inheritance

We can also define more generic type parameters on a subinterface or we can also inherite a non-generic interface from a generic
interface.

```
public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> 
    where T : IEntity
{}

public interface IEmployeeRepository : IRepository<Employee>
{

}
```

The same concept is applied to classes:

```
public class SEmployeeRepository : IRepository<Employee>
{
    public void Add(Employee item)
    {
        throw new NotImplementedException();
    }

    ...
}
```

We can also create a GenericSuperRepository class:

```
public class GenericSuperRepository<T> : IRepository<T> where T : IEntity
{
    public void Add(T item)
    {
        throw new NotImplementedException();
    }

    ...
}
```

# CHAPTER 05 - Creating generic methods and delegates

How to make our methods and delegates reusable by making them generics.

## Creating a generic method

```
static void AddBatch<T>(IWriteRepository<T> repo, T[] items) 
{
    foreach (var item in items)
    {
        repo.Add(item);
    }
    
    repo.Save();
}

static void AddOrganizations(IRepository<Organization> repo)
{
    var organizations = new[]
    {
        new Organization { Name = "Pluralsight" },
        new Organization { Name = "Globomantics" }
    };

    AddBatch(repo, organizations);

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
```