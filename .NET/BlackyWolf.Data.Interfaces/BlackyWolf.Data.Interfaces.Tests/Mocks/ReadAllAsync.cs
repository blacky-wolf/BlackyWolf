namespace BlackyWolf.Data.Interfaces.Tests.Mocks;

internal class ReadAllAsync : IReadAllAsync<Customer>
{
    private readonly IEnumerable<Customer> customers;

    public ReadAllAsync(IEnumerable<Customer> customers) => this.customers = customers;

    public Task<IEnumerable<Customer>> ReadAsync() => Task.FromResult(customers);
}
