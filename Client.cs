namespace Workshop;

/// <summary>
/// Представляет клиента мастерской
/// </summary>
public class Client
{
    /// <summary>
    /// Уникальный идентификатор клиента
    /// </summary>
    public int Id { get; }
    /// <summary>
    /// Фамилия клиента
    /// </summary>
    public string LastName { get; }
    /// <summary>
    /// Имя клиента
    /// </summary>
    public string FirstName { get; }
    /// <summary>
    /// Отчество клиента
    /// </summary>
    public string Patronymic { get; }

    /// <summary>
    /// Телефон клиента
    /// </summary>
    public string Phone { get; }

    /// <summary>
    /// Email клиента
    /// </summary>
    public string? Email { get; }

    /// <summary>
    /// Конструктор клиента
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="lastName">Фамилия</param>
    /// <param name="firstName">Имя</param>
    /// <param name="patronymic">Отчество</param>
    /// <param name="phone">Телефон</param>
    /// <param name="email">Email</param>
    public Client(int id, string lastName,string firstName,string patronymic, string phone, string email)
    {
        Id = id;
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        Patronymic = patronymic ?? throw new ArgumentNullException(nameof(patronymic));
        
        Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        Email = email ?? throw new ArgumentNullException(nameof(email));
    }
}