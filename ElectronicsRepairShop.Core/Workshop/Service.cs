namespace ElectronicsRepairShop.Core.Workshop;

public record Service
{
    protected Service(string id, string name, decimal price)
    {
        if (Guid.TryParse(id, out var result))
        {
            Id = result;
        }
        else
        {
            throw new Exception($"Can't parse id {id}");
        }

        Name = name;

        if (price > 0)
        {
            Price = price;
        }
        else
        {
            throw new Exception("Price is less than zero");
        }
    }

    public Guid Id { get; }
    public string Name { get; }
    public decimal Price { get; }
}