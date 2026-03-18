namespace ElectronicRepairShop.Core.Entities.Devices;


/// <summary>
/// Представляет базовый абстрактный класс для всех типов электроных устройств в системе учёта.
/// </summary>
/// <remarks>
/// Класс содержит общие индентификационные данные, обязательные для любого оборудования.
/// При наследование необходимо определить специфичную категорию устройства.
/// </remarks>>

public abstract class Device
{
    
    public required string Brand { get; init; }
    public required string Model { get; init; }
    public required string SerialNumber { get; init; }

    /// <summary>
    /// При переопределение в производном классе возвращает категорию устройства
    /// </summary>
    /// <seealso cref="DeviceCategory"/>>
    public abstract DeviceCategory Category { get; }
}