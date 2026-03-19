namespace ElectronicRepairShop.Core.Entities.Parts;


/// <summary>
/// Класс представляет информацию о характеристике центрального процессора.
/// </summary>
public class Processor : Part
{
    /// <summary>
    /// Количество физический ядер.
    /// </summary>
    public required uint Cores { get; init; }
    /// <summary>
    /// Базовая тактовая частота в ГГц.
    /// </summary>
    public required double BaseFrequency { get; init; }
}