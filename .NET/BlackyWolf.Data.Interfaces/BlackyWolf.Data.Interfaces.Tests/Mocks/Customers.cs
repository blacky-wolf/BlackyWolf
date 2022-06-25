namespace BlackyWolf.Data.Interfaces.Tests.Mocks;

internal static class Customers
{
    public static string PredfinedGuid => "1b6b1fd6-ded3-42b2-808c-fc9e2f1983f1";

    public static List<Customer> List
    {
        get
        {
            var list = Enumerable.Range(1, 9)
                .Select(x => new Customer(
                    Name: $"Customer {x}",
                    Age: (x + 1) % 3 * 5)
                )
                .ToList();

            list.Add(new Customer("Bob boy", 1176) { Id = PredfinedGuid });

            return list;
        }
    }
}
