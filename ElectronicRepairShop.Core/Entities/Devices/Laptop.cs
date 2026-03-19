using ElectronicRepairShop.Core.Entities.Parts;

namespace ElectronicRepairShop.Core.Entities.Devices;

/// <summary>
/// Класс представляет информацию о ноутбке 
/// </summary>
public class Laptop : Device
{
    public override DeviceCategory Category => DeviceCategory.Laptop;
    
    /// <summary>
    /// Характеристики установленого дисплея.
    /// </summary>
    /// <see cref="Display"/>>
    public required Display Display { get; init; }
    
    /// <summary>
    /// Характеристики установленного центрального процессора.
    /// </summary>
    /// <see cref="Processor"/>>
    public required Processor Processor { get; init; }
}