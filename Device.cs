namespace Workshop;

/// <summary>
/// Абстрактный базовый класс для электронных устройств,
/// принимаемых в ремонт
/// </summary>
public abstract class Device
{
    /// <summary>
    /// Уникальный идентификатор устройства 
    /// </summary>
    public int Id { get; }
    /// <summary>
    /// Бренд/производитель устройства
    /// </summary>
    /// <example>Dell, Samsung, Apple</example>
    public string Brand { get; }
    /// <summary>
    /// Модель устройства
    /// </summary>
    /// <example>XPS13, Galaxy S23, iPad Air</example>
    public string Model { get; }
    /// <summary>
    /// Серийный номер устройства
    /// </summary>
    /// <example>SN123456789</example>
    public string SerialNumber { get; }
    /// <summary>
    /// Описание неисправности от клиента
    /// </summary>
    /// <example>"Не включается", "Не заряжается", "Экран мигает"</example>
    public string IssueDescription { get; set; }
    /// <summary>
    /// Тип устройства
    /// </summary>
    /// <example>Ноутбук,Смартфон,Планшет,</example>
    public DeviceType DeviceType { get; }

    /// <summary>
    /// Создаёт новое устройство
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="brand">Бренд</param>
    /// <param name="model">Модель</param>
    /// <param name="serialNumber">Серийный номер</param>
    /// <param name="issueDescription">Описание проблемы</param>
    /// <param name="deviceType">Тип устройства</param>
    protected Device(int id, string brand, string model, string serialNumber, string issueDescription, DeviceType deviceType)
    {
        Id = id;
        Brand = brand ?? throw new ArgumentNullException(nameof(brand));
        Model = model ?? throw new ArgumentNullException(nameof(model));
        SerialNumber = serialNumber ?? throw new ArgumentNullException(nameof(serialNumber));
        IssueDescription = issueDescription ?? throw new ArgumentNullException(nameof(issueDescription));
        DeviceType = deviceType;
    }
    /// <summary>
    /// Возвращает тип устройства для специализации инженеров
    /// </summary>
    /// <returns>Название типа: "Ноутбук", "Смартфон", "Планшет"</returns>
    public abstract string GetDeviceType();
    
    /// <summary>
    /// Выводит полную информацию об устройстве в консоль
    /// </summary>
    public virtual string PrintInfo() =>
        $"{Brand}, {Model}, {SerialNumber}, {IssueDescription}, {DeviceType}";
}