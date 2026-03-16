namespace Workshop;

/// <summary>
/// Запчасть на складе мастерской
/// </summary>
public class Part
{
    /// <summary>
    /// Уникальный идентификатор 
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Название запчасти
    /// </summary>
    /// <example>"Батарея", "Экран", "Шлейф"</example>
    public string Name { get; }

    /// <summary>
    /// Артикул запчасти
    /// </summary>
    public string Article { get; }
    /// <summary>
    /// Закупочная цена
    /// </summary>
    public decimal PurchasePrice { get; }
    /// <summary>
    /// Цена продажи клиенту
    /// </summary>
    public decimal SellingPrice { get; }
    /// <summary>
    /// Остаток на складе
    /// </summary>
    public int QuantityInStock { get; private set; }
    
    /// <summary>
    /// Создаёт новую запчасть
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="name">Название</param>
    /// <param name="article">Артикул</param>
    /// <param name="purchasePrice">Закупочная цена</param>
    /// <param name="sellingPrice">Цена продажи</param>
    /// <param name="quantityInStock">Начальный остаток (по умолчанию 0)</param>

    public Part(int id, string name, string article, decimal purchasePrice,decimal sellingPrice, int quantityInStock = 0)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Article = article ?? throw new ArgumentNullException(nameof(article));
        PurchasePrice = purchasePrice >= 0
            ? purchasePrice
            : throw new ArgumentException("Закупочная цена не может быть отрицательной");
        SellingPrice = sellingPrice >= 0
            ? sellingPrice
            : throw new ArgumentException("Продажная цена не может быть отрицательной");
        QuantityInStock = quantityInStock >= 0
            ? quantityInStock
            : throw new ArgumentException("Количество не может быть отрицательным");
    }


    /// <summary>
    /// Списывает запчасть со склада
    /// </summary>
    /// <param name="quantity">Количество для списания</param>
    /// <exception cref="ArgumentException"><paramref name="quantity"/> меньше или равно 0</exception>
    /// <exception cref="InvalidOperationException">Недостаточно запчастей на складе</exception>
    public void DecreaseStock(int quantity)
    {
        if (quantity <= 0) throw new ArgumentException("Количество должно быть положительным");
        if (QuantityInStock < quantity)
            throw new InvalidOperationException($"Недостаточно запчастей {Name}. В наличии: {QuantityInStock}");

        QuantityInStock -= quantity;
    }

    /// <summary>
    /// Пополняет склад запчастями
    /// </summary>
    /// <param name="quantity">Количество для добавления</param>
    /// <exception cref="ArgumentException"><paramref name="quantity"/> меньше или равно 0</exception>
    public void IncreaseStock(int quantity)
    {
        if (quantity <= 0) throw new ArgumentException("Количество должно быть положительным");
        QuantityInStock += quantity;
    }
}