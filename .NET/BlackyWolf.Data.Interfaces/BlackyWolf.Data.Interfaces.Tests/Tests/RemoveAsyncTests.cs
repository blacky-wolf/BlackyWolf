using BlackyWolf.Data.Interfaces.Tests.Mocks;

namespace BlackyWolf.Data.Interfaces.Tests.Tests;

[Trait("Action", "Write")]
public class RemoveAsyncTests
{
    private readonly List<Customer> customers;
    private readonly IRemoveAsync<Customer> dbOne;
    private readonly IRemoveAsync<Customer, bool> dbTwo;

    public RemoveAsyncTests()
    {
        customers = Customers.List;

        var remover = new RemoveAsync(customers);

        dbOne = remover;
        dbTwo = remover;
    }

    [Fact]
    public async Task IRemoveAsync_Removes_Customer_Void()
    {
        // Assign
        Customer customer = customers.First(x => x.Id == Customers.PredfinedGuid);

        // Act
        await dbOne.RemoveAsync(customer);

        var exists = customers.Any(x => x.Id == Customers.PredfinedGuid);

        // Assert
        Assert.Equal(9, customers.Count);
        Assert.False(exists);
    }

    [Fact]
    public async Task IRemoveAsync_Removes_Customer_WithBool()
    {
        // Assign
        Customer customer = customers.First(x => x.Id == Customers.PredfinedGuid);

        // Act
        var removed = await dbTwo.RemoveAsync(customer);

        var exists = customers.Any(x => x.Id == Customers.PredfinedGuid);

        // Assert
        Assert.Equal(9, customers.Count);
        Assert.True(removed);
        Assert.False(exists);
    }
}
