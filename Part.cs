namespace ElectronicsWorkshop;

public class Part 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Article { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SellingPrice { get; set; }
    public int QuantityInStock { get; set; }

    public Part(int id, string name, string article, decimal purchasePrice, decimal sellingPrice, int quantityInStock)
    {
        Id = id;
        Name = name;
        Article = article;
        PurchasePrice = purchasePrice;
        SellingPrice = sellingPrice;
        QuantityInStock = quantityInStock;
    }
    
    public void DecreaseStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("The quantity must be positive");
                
        if (QuantityInStock < quantity)
            throw new InvalidOperationException(
                $"Not enough spare parts in stock.");
                
        QuantityInStock -= quantity;
    }

    public void IncreaseStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("The quantity must be positive");
                
        QuantityInStock += quantity;
    }

    public override string ToString()
    {
        return $"{Name} ({Article}) - {QuantityInStock} in stock";
    }
}