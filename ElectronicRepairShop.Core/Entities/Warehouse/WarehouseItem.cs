using ElectronicRepairShop.Core.Entities.Parts;

namespace ElectronicRepairShop.Core.Entities.Warehouse;


/// <summary>
/// Класс представляет единицк товара на складе с учётом цен и текущего остатка.
/// </summary>

public class WarehouseItem
{
    public required Part Part { get; init; }
    
    public decimal PurchasePrice { get; set; }
    public decimal SellingPrice { get; init; }
    public int QuantityInStock { get; set; }
    
    public string Article => Part.Article;
}