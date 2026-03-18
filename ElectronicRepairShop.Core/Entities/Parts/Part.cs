using System;

namespace ElectronicRepairShop.Core.Entities.Parts;


/// <summary>
/// Класс представляет информацияю о запчасти 
/// </summary>
public class Part
{
    public required Guid Id { get; init; }
    public required string Article { get; init; }
    public required string Brand { get; init; }
    public required string Model { get; init;  }
}