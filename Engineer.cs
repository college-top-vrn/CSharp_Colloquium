namespace Workshop;

/// <summary>
/// Инженер-ремонтник мастерской
/// </summary>
public class Engineer
{
    /// <summary>
    /// Уникальный идентификатор инженера
    /// </summary>
    
    public int Id { get; }
    /// <summary>
    /// Фамилия инжинера
    /// </summary>
    public string LastName { get; }
    /// <summary>
    /// Имя инжинера
    /// </summary>
    public string FirstName { get; }
    /// <summary>
    /// Отчество инжинера
    /// </summary>
    public string Patronymic { get; }
    /// <summary>
    /// Список специализаций инженера
    /// </summary>
    /// <remarks>Определяет типы устройств, которые может ремонтировать</remarks>
    public List<DeviceType> Specialization { get;  }

    
    /// <summary>
    /// Создаёт нового инженера
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="lastName">Фамилия</param>
    /// <param name="firstName">Имя</param>
    /// <param name="patronymic">Отчество</param>
    /// <param name="specialization">Специализации</param>
    /// <exception cref="ArgumentNullException"> 
    /// <paramref name="lastName"/> или <paramref name="firstName"/>  или <paramref name="patronymic"/> или <paramref name="specialization"/> равен <see langword="null"/>
    /// </exception>
    public Engineer(int id, string lastName,string firstName,string patronymic, List<DeviceType> specialization){
        Id = id;
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        Patronymic = patronymic ?? throw new ArgumentNullException(nameof(patronymic));
        Specialization = specialization ?? throw new ArgumentNullException(nameof(specialization));
    }
    /// <summary>
    /// Проверяет, может ли инженер ремонтировать конкретное устройство
    /// </summary>
    /// <param name="device">Устройство для проверки</param>
    /// <returns>
    /// <see langword="true"/> если специализация совпадает с типом устройства
    /// </returns>
    /// <returns>
    /// <see langword="false"/> если специализация не совпадает с типом устройства
    /// </returns>
    public bool CanRepair(Device device)
    {
        foreach (var specialization in Specialization)
        {
            var deviceType = specialization.ToString();
            if (deviceType == device.GetDeviceType())
            {
                return true;
            }
        }
        return false;
    }
}