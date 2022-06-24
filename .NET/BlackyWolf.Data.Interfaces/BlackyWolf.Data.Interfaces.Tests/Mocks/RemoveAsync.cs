namespace BlackyWolf.Data.Interfaces.Tests.Mocks;

internal class RemoveAsync : IRemoveAsync<Customer>, IRemoveAsync<Customer, bool>
{
    private readonly ICollection<Customer> customers;

    public RemoveAsync(ICollection<Customer> customers) => this.customers = customers;

    async Task IRemoveAsync<Customer>.RemoveAsync(Customer data)
    {
        customers.Remove(data);

        await Task.CompletedTask;
    }

    async Task<bool> IRemoveAsync<Customer, bool>.RemoveAsync(Customer data)
        => await Task.FromResult(customers.Remove(data));
}
