using System;
using ElectronicRepairShop.Core.Entities.Enums;

namespace ElectronicRepairShop.Core.Entities.People;

/// <summary>
/// Класс представляет информацию о клиенте системы
/// </summary>
public class Client : Person
{
    /// <summary> Дата и время регистрации клиента в системе </summary>
    public required DateTime RegisteredAt { get; init; }

    public required ClientType ClientType { get; init; }

    public decimal PersonalDiscount { get; set; }
}