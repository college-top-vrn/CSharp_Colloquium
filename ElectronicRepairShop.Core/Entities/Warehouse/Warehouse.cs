using System;
using System.Collections.Generic;

namespace ElectronicRepairShop.Core.Entities.Warehouse;

public class Warehouse
{
    private readonly Dictionary<string, WarehouseItem> _inventory = new();

    public void AddStock(WarehouseItem item)
    {
        if (_inventory.TryGetValue(item.Part.Article, out var existingItem))
        {
            existingItem.QuantityInStock += item.QuantityInStock;
            return;
        }

        _inventory.Add(item.Part.Article, item);
    }


    public WarehouseItem? GetItem(string article)
    {
        _inventory.TryGetValue(article, out var item);
        return item; 
    }
    
    
}