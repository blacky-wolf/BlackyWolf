namespace BlackyWolf.Data.Interfaces.Tests.Mocks;

internal record Customer(string Name, int Age)
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
}
