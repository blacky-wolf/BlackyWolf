using BlackyWolf.Data.Interfaces.Tests.Mocks;

namespace BlackyWolf.Data.Interfaces.Tests.Tests;

[Trait("Action", "Read")]
public class ReadAllAsyncTests
{
    private readonly List<Customer> customers;
    private readonly IReadAllAsync<Customer> db;

    public ReadAllAsyncTests()
    {
        customers = Customers.List;

        db = new ReadAllAsync(customers);
    }

    [Fact]
    public async Task IReadAllAsync_Gets_All_Customers()
    {
        // Assign/Act
        IEnumerable<Customer> list = await db.ReadAsync();

        // Assert
        Assert.True(list.Any());
        Assert.True(list.Count() == customers.Count);
    }
}
