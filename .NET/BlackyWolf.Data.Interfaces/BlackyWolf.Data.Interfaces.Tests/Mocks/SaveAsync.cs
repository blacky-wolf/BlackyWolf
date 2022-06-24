namespace BlackyWolf.Data.Interfaces.Tests.Mocks;

internal class SaveAsync : ISaveAsync<Customer>, ISaveAsync<Customer, string>
{
    private readonly ICollection<Customer> customers;

    public SaveAsync(ICollection<Customer> customers) => this.customers = customers;

    async Task ISaveAsync<Customer>.SaveAsync(Customer data)
    {
        data.Id = Guid.NewGuid().ToString();

        customers.Add(data);

        await Task.CompletedTask;
    }

    async Task<string> ISaveAsync<Customer, string>.SaveAsync(Customer data)
    {
        data.Id = Guid.NewGuid().ToString();

        customers.Add(data);

        return await Task.FromResult(data.Id);
    }
}
