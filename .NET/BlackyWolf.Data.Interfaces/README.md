# BlackyWolf.Data.Interfaces

This package contains modular interfaces for working with data.

## Using this package

This package is available from NuGet.

The way to properly use this package is to install it in your project and implement the interfaces in a modular way so you can decouple logic and better maintain your code.

At the moment there are only asynchronous interfaces. I will add synchronous types in the future. The asynchronous methods all return a `Task` or `Task<T>`. I considered using `ValueTask<T>` but in the end thought it might be too limiting. It may be worth splitting these interfaces into separate namespaces to return Tasks and ValueTasks. Not sure.

While the separation of interfaces may seem overkill for most scenarios, this has been done to adhere to interface segregation. Also, I kept running into situations where I needed to use both EF Core, Dapper, and the native SQL APIs. Not only this, I keep running into situations where I simply don't need all of the functionality from a `DbContext`, etc.

### Dependency Injection

While it is absolutely valid to create an implementation for every single type of entity you have, it can be a pain to maintain. Where possible, I recommend using generic types on the implementation and registering them with dependency injection like so in the case of EF Core:

```csharp
// EF Core example
public class GenericReadAllAsync<TEntity> : IReadAllAsync<TEntity>
{
    private readonly DbContext context;

    public GenericReadAllAsync(DbContext context)
        => this.context = context;

    public async Task<TEntity> ReadAsync()
    {
        return await context.Set<TEntity>().ToListAsync();
    }
}
```

And then in the `IServiceCollection`:

```csharp
services.AddScoped(typeof(IReadAllAsync<>), typeof(GenericReadAllAsync<>));
```

## Interfaces

### IReadAllAsync

Used to retrieve all entities, records, rows, etc. from a data source.

```csharp
public interface IReadAllAsync<TData>
{
    Task<IEnumerable<TData>> ReadAsync();
}
```

`TData` is the generic type which represents the data you wish to return. It can be any type.

It returns an `IEnumerable<TData>` to allow for as many enumerable types as possible, outside of something such as `IAsyncEnumerable`.

Please note that if no records are found you should return an empty enumerable rather tha null.

While this can be used to retrieve every record, you probably don't want to do that in every situation. In such cases, I recommend implementing the `IReadByCriteriaAsync` interface.

### IReadByKeyAsync

Used to retrieve a single entity, record, row, etc. from a data source.

```csharp
public interface IReadByKeyAsync<in TKey, TData>
{
    Task<TData?> ReadAsync(TKey key);
}
```

`TKey` is the type of the primary identifier used to locate the single entity. It can be any type.

`TData` is the generic type which represents the data you wish to return. It can be any type.

It returns a `TData` if found, otherwise, it is recommend to return null instead of throwing an error.

While `TKey` may be used primarily for primitive types such as string and int, it is also possible, and encouraged where necessary, to pass in more complex types. This can either be as a class, struct, record, or even tuple:

```csharp
public class CustomerInvoiceReader : IReadByKey<(int customerId, string invoiceId), Invoice>
{
    public async Task<Invoice> ReadAsync((int customerId, string invoiceId) key)
    {
        (var customerId, var invoiceId) = key;

        var invoice = await GetInvoiceByCustomer(customerId, invoiceId);

        return invoice;
    }
}
```