namespace BlackyWolf.Data.Interfaces.Tests.Mocks;

internal class ReadByCriteriaAsync : IReadByCriteriaAsync<(int skip, int take), Customer>
{
    private readonly IEnumerable<Customer> customers;

    public ReadByCriteriaAsync(IEnumerable<Customer> customers) => this.customers = customers;

    public Task<IEnumerable<Customer>> ReadAsync((int skip, int take) criteria)
    {
        (var skip, var take) = criteria;

        return Task.FromResult(customers.Skip(skip).Take(take));
    }
}
