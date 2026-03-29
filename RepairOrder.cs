namespace Workshop;
/// <summary>
/// Заказ на ремонт электронного устройства
/// </summary>
/// <implements cref="IRepairable"/>
public class RepairOrder : IRepairable
{
    /// <summary>
    /// Номер заказа
    /// </summary>
    public int Id { get; }
    /// <summary>
    /// Клиент
    /// </summary>
    public Client Client { get; }
    /// <summary>
    /// Устройство в ремонте
    /// </summary>
    public Device Device { get; }
    /// <summary>
    /// Назначенный инженер (null до назначения)
    /// </summary>
    public Engineer? Engineer { get; private set; }
    /// <summary>
    /// Дата и время приёма заказа
    /// </summary>
    public DateTime ReceivedDate { get; }
    /// <summary>
    /// Дата завершения ремонта (null до завершения)
    /// </summary>
    public DateTime? CompletionDate { get; private set; }
    /// <summary>
    /// Текущий статус заказа
    /// </summary>
    public RepairStatus Status { get; private set; }
    /// <summary>
    /// Список оказанных услуг
    /// </summary>
    public List<Service> Services { get; } = new();
    /// <summary>
    /// Использованные запчасти (Part, Quantity)
    /// </summary>
    public List<(Part Part, int Quantity)> UsedParts { get; } = new();
    /// <summary>
    /// Общая стоимость заказа (вычисляется автоматически)
    /// </summary>
    public decimal TotalCost => CalculateTotalCost();
    /// <summary>
    /// Создаёт новый заказ на ремонт
    /// </summary>
    /// <param name="id">Номер заказа</param>
    /// <param name="client">Клиент</param>
    /// <param name="device">Устройство</param>
    /// <param name="issueDescription">Описание неисправности</param>
    public RepairOrder(int id, Client client, Device device, string issueDescription)
    {
        Id = id;
        Client = client;
        Device = device;
        Device.IssueDescription = issueDescription;
        ReceivedDate = DateTime.Now;
        Status = RepairStatus.Received;
    }

    /// <summary>
    /// Добавляет услугу к заказу
    /// </summary>
    /// <param name="service">Услуга</param>
    /// <exception cref="InvalidOperationException">Заказ завершён</exception>
    public void AddService(Service service)
    {
        if (service == null) throw new ArgumentNullException(nameof(service));
        if (Status == RepairStatus.Issued || Status == RepairStatus.Rejected)
            throw new InvalidOperationException("Нельзя добавлять услуги к завершенному заказу");
        
        Services.Add(service);
    }

    /// <summary>
    /// Добавляет запчасть к заказу
    /// </summary>
    /// <param name="part">Запчасть</param>
    /// <param name="quantity">Количество</param>
    /// <exception cref="InvalidOperationException">заказ завершён</exception>
    /// <exception cref="ArgumentNullException"><paramref name="part"/> равен <see langword="null"/></exception>
    public void AddPart(Part part, int quantity)
    {
        if (part == null) throw new ArgumentNullException(nameof(part));
        if (Status == RepairStatus.Issued || Status == RepairStatus.Rejected)
            throw new InvalidOperationException("Нельзя добавлять запчасти к завершенному заказу");
        
        part.DecreaseStock(quantity);
        UsedParts.Add((part, quantity));
    }
    
    /// <summary>
    /// Рассчитывает итоговую стоимость заказа
    /// </summary>
    /// <returns>Сумма цен услуг + запчастей</returns>
    public decimal CalculateTotalCost()
    {
        decimal servicesCost = Services.Sum(s => s.Price);
        decimal partsCost = UsedParts.Sum(up => up.Part.SellingPrice * up.Quantity);
        return servicesCost + partsCost;
    }

    /// <summary>
    /// Изменяет статус заказа
    /// </summary>
    /// <param name="newStatus">Новый статус</param>
    /// <exception cref="InvalidOperationException">Недопустимый переход статуса</exception>
    public void ChangeStatus(RepairStatus newStatus)
    {

        if (Status == RepairStatus.Issued && newStatus != RepairStatus.Issued)
            throw new InvalidOperationException("Выданный заказ нельзя изменить");
        
        if (Status == RepairStatus.Rejected && newStatus != RepairStatus.Rejected)
            throw new InvalidOperationException("Отклоненный заказ нельзя изменить");

        Status = newStatus;
    }


    /// <summary>
    /// Завершает заказ
    /// </summary>
    public void CompleteOrder()
    {
        CompletionDate = DateTime.Now;
        Status = RepairStatus.Ready;
    }
    
    /// <summary>
    /// Назначает инженера на заказ
    /// </summary>
    /// <param name="engineer">Инженер</param>
    /// <exception cref="InvalidOperationException">заказ завершён</exception>
    public bool AssignEngineer(Engineer engineer)
    {
        if (!engineer.CanRepair(Device))
            return false;
        
        if (Status == RepairStatus.Issued || Status == RepairStatus.Rejected)
            throw new InvalidOperationException("Нельзя назначать инженера завершенному заказу");
        
        Engineer = engineer;
        Status = RepairStatus.Diagnostics;
        return true;
    }
    
    /// <summary>
    /// Проводит диагностику
    /// </summary>
    public string Diagnose()
    {
        if (Status != RepairStatus.Received)
            throw new InvalidOperationException("Диагностику можно провести только для принятых заказов");
        
        Status = RepairStatus.Diagnostics;
        return $"Диагностика заказа #{Id} ({Device.Brand} {Device.Model}) начата";
    }
    
    /// <summary>
    /// Выполняет ремонт
    /// </summary>
    public string Repair()
    {
        if (Engineer == null)
            throw new InvalidOperationException("Для ремонта требуется назначенный инженер");
        
        if (Status != RepairStatus.Diagnostics)
            throw new InvalidOperationException("Ремонт можно начать только после диагностики");
        
        Status = RepairStatus.InProgress;
        
        return $"Ремонт заказа №{Id} начата инженером {Engineer.FirstName} {Engineer.LastName} {Engineer.Patronymic}";
    }
}