using System;

namespace ElectronicRepairShop.Core.Entities.People;


/// <summary>
/// Базовый класс для всех физический лиц в системе.
/// </summary>
public abstract class Person
{
    public required Guid Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string? Patronymic { get; init; }

    public required string Phone { get; set; }
    public required string Email { get; set; }

    /// <summary>
    /// Вычисляемое свойство для вывода
    /// </summary>
    public string FullName => $"{LastName} {FirstName} {Patronymic}".Trim(); 
}