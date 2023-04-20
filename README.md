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