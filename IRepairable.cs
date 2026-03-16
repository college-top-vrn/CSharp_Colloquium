namespace Workshop;

/// <summary>
/// Интерфейс для объектов, подлежащих ремонту
/// </summary>
public interface IRepairable
{
    /// <summary>
    /// Проводит диагностику
    /// </summary>
    void Diagnose();
    
    /// <summary>
    /// Выполняет ремонт
    /// </summary>
    void Repair();
}