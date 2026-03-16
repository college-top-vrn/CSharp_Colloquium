namespace ElectronicsWorkshop;

public class WorkShop
{
    public List<Client> Clients { get; set; }
    public List<Device> Devices { get; set; }
    public List<Engineer> Engineers { get; set; }
    public List<RepairOrder> Orders { get; set; }
    public List<Part> Parts { get; set; }
    public List<Servise> Services { get; set; }

    public WorkShop()
    {
        Clients = new List<Client>();
        Devices = new List<Device>();
        Engineers = new List<Engineer>();
        Orders = new List<RepairOrder>();
        Parts = new List<Part>();
        Services = new List<Servise>();
    }

    public void AddClient(Client client)
    {
        if (!Clients.Contains(client))
            Clients.Add(client);
    }
    
    public void AddEngineer(Engineer engineer)
    {
        if (!Engineers.Contains(engineer))
            Engineers.Add(engineer);
    }

    public void AddPart(Part part)
    {
        var existingPart = Parts.FirstOrDefault(p => p.Id == part.Id);
        if (existingPart != null)
        {
            existingPart.IncreaseStock(part.QuantityInStock);
        }
        else
        {
            Parts.Add(part);
        }
    }
    
    public void AddService(Servise service)
    {
        if (!Services.Contains(service))
            Services.Add(service);
    }
    
    public RepairOrder CreateOrder(Client client, Device device, string issueDescription)
    {
        if (!Clients.Any(c => c.Id == client.Id))
            AddClient(client);
        if (!Devices.Any(d => d.Id == device.Id))
            Devices.Add(device);
                
        int orderId = Orders.Count > 0 ? Orders.Max(o => o.Id) + 1 : 1;
        var order = new RepairOrder(orderId, client, device, issueDescription);
        
        Orders.Add(order);
            
        return order;
    }
    
    public bool AssignEngineer(int orderId, int engineerId)
    {
        var order = Orders.FirstOrDefault(o => o.Id == orderId);
        if (order == null)
            throw new ArgumentException($"Order {orderId} not found");
                
        var engineer = Engineers.FirstOrDefault(e => e.Id == engineerId);
        if (engineer == null)
            throw new ArgumentException($"Engineer {engineerId} not found");
                
        if (!engineer.CanRepair(order.Device))
            return false;
                
        order.Engineer = engineer;
        return true;
    }
    
    public List<RepairOrder> GetOrdersByStatus(RepairStatus status)
    {
        return Orders.Where(o => o.Status == status).ToList();
    }

    public decimal GetRevenue(DateTime from, DateTime to)
    {
        return Orders
            .Where(o => o.Status == RepairStatus.Issued && 
                        o.CompletionDate.HasValue &&
                        o.CompletionDate.Value.Date >= from.Date && 
                        o.CompletionDate.Value.Date <= to.Date)
            .Sum(o => o.TotalCost);
    }
    
    public void RestockPart(int partId, int quantity)
    {
        var part = Parts.FirstOrDefault(p => p.Id == partId);
        if (part == null)
            throw new ArgumentException($"{partId} not found");
                
        part.IncreaseStock(quantity);
    }
}