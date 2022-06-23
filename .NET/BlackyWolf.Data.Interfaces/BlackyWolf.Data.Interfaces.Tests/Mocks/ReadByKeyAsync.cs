namespace BlackyWolf.Data.Interfaces.Tests.Mocks;

internal class ReadByKeyAsync : IReadByKeyAsync<string, Customer>
{
    private readonly IEnumerable<Customer> customers;

    public ReadByKeyAsync(IEnumerable<Customer> customers) => this.customers = customers;

    public Task<Customer?> ReadAsync(string key) => Task.FromResult(customers.FirstOrDefault(x => x.Id == key));
}
