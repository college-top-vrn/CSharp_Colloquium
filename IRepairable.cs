namespace Workshop;

/// <summary>
/// Интерфейс для объектов, подлежащих ремонту
/// </summary>
public interface IRepairable
{
    /// <summary>
    /// Проводит диагностику
    /// </summary>
    string Diagnose();
    
    /// <summary>
    /// Выполняет ремонт
    /// </summary>
    string Repair();
}