namespace Workshop;

/// <summary>
/// Статусы заказа на ремонт
/// </summary>
public enum RepairStatus
{
    Received,      // Принят
    Diagnostics,   // Диагностика
    InProgress,    // В ремонте
    Ready,         // Готов к выдаче
    Issued,        // Выдан
    Rejected       // Отказ от ремонта
}