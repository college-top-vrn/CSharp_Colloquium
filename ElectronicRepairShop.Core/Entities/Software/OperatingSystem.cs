namespace ElectronicRepairShop.Core.Entities.Software;


/// <summary>
/// Класс представляет информацию об операционной системе устройства.
/// </summary>
public class OperatingSystem
{
    /// <summary>
    /// Основное название OC (например: Android, IOS, Windows).
    /// </summary>
    public required string Name { get; init; }
    /// <summary>
    /// Версия OC.
    /// </summary>
    public required string Version { get; init;  }
    /// <summary>
    /// Специфичная оболочка производителя (например: One UI).
    /// Moжет быть null.
    /// </summary>
    public required string? Shell { get; init; }
    
}