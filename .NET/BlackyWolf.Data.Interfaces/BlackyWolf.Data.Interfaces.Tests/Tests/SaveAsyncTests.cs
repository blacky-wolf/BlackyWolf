using BlackyWolf.Data.Interfaces.Tests.Mocks;

namespace BlackyWolf.Data.Interfaces.Tests.Tests;

[Trait("Action", "Write")]
public class SaveAsyncTests
{
    private readonly List<Customer> customers;
    private readonly ISaveAsync<Customer> dbOne;
    private readonly ISaveAsync<Customer, string> dbTwo;

    public SaveAsyncTests()
    {
        customers = Customers.List;

        var saver = new SaveAsync(customers);

        dbOne = saver;
        dbTwo = saver;
    }

    [Fact]
    public async Task ISaveAsync_Saves_NewCustomer_Void()
    {
        // Assign
        var customer = new Customer("Yuh", 2);

        // Act
        await dbOne.SaveAsync(customer);

        // Assert
        Assert.Equal(11, customers.Count);
        Assert.True(!string.IsNullOrWhiteSpace(customer.Id));
        Assert.True(Guid.TryParse(customer.Id, out _));
    }

    [Fact]
    public async Task ISaveAsync_Saves_NewCustomer_WithId()
    {
        // Assign
        var customer = new Customer("Yuh", 2);

        // Act
        var id = await dbTwo.SaveAsync(customer);

        // Assert
        Assert.Equal(11, customers.Count);
        Assert.True(!string.IsNullOrWhiteSpace(id));
        Assert.True(!string.IsNullOrWhiteSpace(customer.Id));
        Assert.True(Guid.TryParse(customer.Id, out _));
        Assert.True(Guid.TryParse(id, out _));
        Assert.Equal(customer.Id, id);
    }
}
