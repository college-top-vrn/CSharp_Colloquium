namespace ElectronicsRepairShop.Core.Workshop;

public record Part
{
    public Part(string id, string name, string article, decimal purchasePrice, decimal sellingPrice)
    {
        Id = Guid.TryParse(id, out var result) ? result : throw new Exception($"Can't parse id {id}");
        Name = string.IsNullOrWhiteSpace(name) ? throw new Exception("Invalid name") : name;
        Article = string.IsNullOrWhiteSpace(article) ? throw new Exception("Invalid article") : article;
        PurchasePrice = purchasePrice > 0 ? purchasePrice : throw new Exception("Purchase price is less than zero");
        SellingPrice = sellingPrice > 0
            ? sellingPrice
            : throw new Exception("Selling price is less than purchase price");
    }

    public Guid Id { get; }
    public string Name { get; }
    public string Article { get; }
    public decimal PurchasePrice { get; }
    public decimal SellingPrice { get; }
}