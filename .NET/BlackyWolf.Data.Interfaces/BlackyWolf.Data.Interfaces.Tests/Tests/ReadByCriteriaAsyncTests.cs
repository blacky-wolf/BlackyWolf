using BlackyWolf.Data.Interfaces.Tests.Mocks;

namespace BlackyWolf.Data.Interfaces.Tests.Tests;

[Trait("Action", "Read")]
public class ReadByCriteriaAsyncTests
{
    private readonly List<Customer> customers;
    private readonly IReadByCriteriaAsync<(int skip, int take), Customer> db;

    public ReadByCriteriaAsyncTests()
    {
        customers = Customers.List;

        db = new ReadByCriteriaAsync(customers);
    }

    [Fact]
    public async Task IReadByCriteriaAsync_Gets_All_Customers_Matching_Criteria()
    {
        // Assign/Act
        IEnumerable<Customer> list = await db.ReadAsync((2, 2));

        // Assert
        Assert.True(list.Any());
        Assert.Equal(2, list.Count());
    }
}
