
using ElectronicRepairShop.Core.Entities.Parts;
using ElectronicRepairShop.Core.Entities.Software;

namespace ElectronicRepairShop.Core.Entities.Devices;

/// <summary>
/// Класс представляет информацию о смартфоне.
/// </summary>

public class Smartphone : Device
{
    public override DeviceCategory Category => DeviceCategory.Smartphone;
    /// <summary>
    /// Характеристики установленого дисплея.
    /// </summary>
    /// <see cref="Display"/>>
    public required Display Display { get; init; }
    
    /// <summary>
    /// Установленная операционная система. 
    /// </summary>
    /// <see cref="OperatingSystem"/>>
    /// 
    public required OperatingSystem OperatingSystem { get; init; }
}