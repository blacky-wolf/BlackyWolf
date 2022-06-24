using BlackyWolf.Data.Interfaces.Tests.Mocks;

namespace BlackyWolf.Data.Interfaces.Tests.Tests;

[Trait("Action", "Read")]
public class ReadByKeyAsyncTests
{
    private readonly List<Customer> customers;
    private readonly IReadByKeyAsync<string, Customer> db;

    public ReadByKeyAsyncTests()
    {
        customers = Customers.List;

        db = new ReadByKeyAsync(customers);
    }

    [Fact]
    public async Task IReadByKeyAsync_Gets_One_Customer()
    {
        // Assign/Act
        Customer? customer = await db.ReadAsync(Customers.PredfinedGuid);

        // Assert
        Assert.NotNull(customer);
        Assert.Equal(Customers.PredfinedGuid, customer?.Id);
    }
}
