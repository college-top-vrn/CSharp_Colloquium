namespace ElectronicsRepairShop.Core;

public record Service
{
    public Service(string id, string name, decimal price)
    {
        Id = Guid.TryParse(id, out Guid result)
            ? result
            : throw new Exception("Invalid id");
        Name = !Utility.IsEmpty(name) || name.IsWhiteSpace()
            ? name
            : throw new Exception("Name is empty");
        Price = price > 0
            ? price
            : throw new Exception("Price is less than 0");
    }
    
    private Guid Id { get; }
    private string Name { get; }
    private decimal Price { get; }
}