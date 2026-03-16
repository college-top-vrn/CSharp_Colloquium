namespace Workshop;
/// <summary>
/// Услуга мастерской
/// </summary>
public class Service
{
    /// <summary>
    /// Уникальный идентификатор услуги
    /// </summary>
    public int Id{get;}
    /// <summary>
    /// Название услуги
    /// </summary>
    /// <example>"Диагностика", "Замена экрана", "Прошивка"</example>
    public string Name { get; }
    /// <summary>
    /// Стоимость услуги
    /// </summary>
    public decimal Price{get;}
    
    /// <summary>
    /// Создаёт новую услугу
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="name">Название</param>
    /// <param name="price">Стоимость</param>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> равен <see langword="null"/></exception>
    /// <exception cref="ArgumentException"><paramref name="price"/> меньше 0</exception>
    
    public Service(int id, string name, decimal price)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Price = price >= 0 
            ? price 
            : throw new ArgumentException("Цена не может быть отрицательной");
    }
}