namespace Workshop;

/// <summary>
///  Класс-менеджер всех сущностей и операций
/// </summary>
public class Workshop
{
    /// <summary>
    ///Список всех клиентов
    /// </summary>
    public List<Client> Clients { get; } = new();
    /// <summary>
    /// Список всех устройств
    /// </summary>
    public List<Device> Devices { get; } = new();
    /// <summary>
    /// Список всех инженеров
    /// </summary>
    public List<Engineer> Engineers { get; } = new();
    /// <summary>
    /// Список всех заказов
    /// </summary>
    public List<RepairOrder> Orders { get; } = new();
    /// <summary>
    /// Список всех запчастей
    /// </summary>
    public List<Part> Parts { get; } = new();
    /// <summary>
    /// Список всех услуг
    /// </summary>
    public List<Service> Services { get; } = new();

    /// <summary>
    /// Добавляет клиента 
    /// </summary>
    /// <param name="client">Клиент</param>
    public void AddClient(Client client)
    {
        if (!Clients.Any(c => c.Id == client.Id))
            Clients.Add(client);
    }

    /// <summary>
    /// Добавляет инженера 
    /// </summary>
    /// <param name="engineer">Инжинер</param>
    public void AddEngineer(Engineer engineer)
    {
        if (!Engineers.Any(e => e.Id == engineer.Id))
            Engineers.Add(engineer);
    }

    /// <summary>
    /// Добавляет запчасть
    /// </summary>
    /// <param name="part">Диталь</param>
    public void AddPart(Part part)
    {
        if (!Parts.Any(p => p.Id == part.Id))
            Parts.Add(part);
    }

    /// <summary>
    /// Добавляет услугу 
    /// </summary>
    /// <param name="service">Услуга</param>
    public void AddService(Service service)
    {
        if (!Services.Any(s => s.Id == service.Id))
            Services.Add(service);
    }   

    /// <summary>
    /// Создаёт новый заказ на ремонт
    /// </summary>
    /// <param name="orderId">Номер заказа (задаётся извне)</param>
    /// <param name="client">Клиент</param>
    /// <param name="device">Устройство</param>
    /// <param name="issueDescription">Описание проблемы</param>
    /// <returns>Созданный заказ</returns>
    public RepairOrder CreateOrder(int orderId, Client client, Device device, string issueDescription)
    {
        AddClient(client);
        Devices.Add(device);
    
        var order = new RepairOrder(orderId, client, device, issueDescription);
        Orders.Add(order);
        return order;
    }

    /// <summary>
    /// Назначает инженера на заказ
    /// </summary>
    /// <param name="orderId">Номер заказа</param>
    /// <param name="engineerId">ID инженера</param>
    /// <returns>true при успехе</returns>
    public bool AssignEngineer(int orderId, int engineerId)
    {
        var order = Orders.FirstOrDefault(o => o.Id == orderId);
        var engineer = Engineers.FirstOrDefault(e => e.Id == engineerId);
        
        if (order == null || engineer == null)
            return false;
            
        return order.AssignEngineer(engineer);
    }
    /// <summary>
    /// Возвращает заказы по статусу
    /// </summary>
    /// <param name="status">Статус</param>
    /// <returns>Список заказов</returns>
    public List<RepairOrder> GetOrdersByStatus(RepairStatus status) =>
        Orders.Where(o => o.Status == status).ToList();

    /// <summary>
    /// Вычисляет выручку за период
    /// </summary>
    /// <param name="from">Дата начала</param>
    /// <param name="to">Дата окончания</param>
    /// <returns>Сумма TotalCost выданных заказов</returns>
    public decimal GetRevenue(DateTime from, DateTime to) =>
        Orders.Where(o => o.Status == RepairStatus.Issued && o.CompletionDate >= from && o.CompletionDate <= to)
            .Sum(o =>o.TotalCost);
    /// <summary>
    /// Пополняет склад запчастями
    /// </summary>
    /// <param name="partId">ID запчасти</param>
    /// <param name="quantity">Количество</param>
    public void RestockPart(int partId, int quantity)
    {
        var part = Parts.FirstOrDefault(p => p.Id == partId);
        part?.IncreaseStock(quantity);
    }
}