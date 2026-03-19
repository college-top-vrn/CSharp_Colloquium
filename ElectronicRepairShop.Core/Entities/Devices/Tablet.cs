using ElectronicRepairShop.Core.Entities.Parts;

namespace ElectronicRepairShop.Core.Entities.Devices;

/// <summary>
/// Класс предствляет информациию о планшете.
/// </summary>

public class Tablet : Device
{
    public override DeviceCategory Category => DeviceCategory.Tablet;
    
    /// <summary>
    /// Характеристики установленого дисплея.
    /// </summary>
    /// <see cref="Display"/>>
    public required Display Display { get; init; }
}