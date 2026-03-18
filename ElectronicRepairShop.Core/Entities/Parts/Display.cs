using ElectronicRepairShop.Core.Entities.Devices;
using ElectronicRepairShop.Core.Entities.Enums;

namespace ElectronicRepairShop.Core.Entities.Parts;

/// <summary>
/// Класс представляет информацию об дисплеее устройства.
/// </summary>
public class Display : Part
{
    public required double DiagonalSize { get; init; }
    public required string Resolution { get; init; }

    /// <summary> Тип используемой матрицы. </summary>
    public PanelType PanelType { get; init; }
}