namespace ElectronicsRepairShop.Core;

public class Part
{
    public Part(string id, string name, string article, decimal purchasePrice, decimal sellingPrice)
    {
        Id = Guid.TryParse(id, out Guid result)
            ? result
            : throw new Exception("Invalid id");
        Name = !Utility.IsEmpty(name) || name.IsWhiteSpace()
            ? name
            : throw new Exception("Name is empty");
        Article = !Utility.IsEmpty(article) || article.IsWhiteSpace()
            ? article
            : throw new Exception("Article is empty");
        PurchasePrice = purchasePrice > 0
            ? purchasePrice
            : throw new Exception("Purchase price is less than 0");
        SellingPrice = sellingPrice > purchasePrice
            ? sellingPrice
            : throw new Exception("Selling price is less than purchase price");
    }
    
    private Guid Id { get;  }
    private string Name { get; }
    private string Article { get; }
    private decimal PurchasePrice { get; }
    private decimal SellingPrice { get; }
}