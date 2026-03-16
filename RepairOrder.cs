namespace ElectronicsWorkshop;

public class RepairOrder
{
    public int Id { get; set; }
    public Client Client { get; set; }
    public Device Device { get; set; }
    public Engineer? Engineer { get; set; }
    public DateTime ReceivedDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public RepairStatus Status { get; set; }
    public List<Servise> Servises { get; set; }
    public List<(Part part, int Quantily)> UsedParts { get; set; }

    public decimal TotalCost => CalculateTotalCost();

    public RepairOrder(int id, Client client, Device device, string issueDescription)
    {
        Id = id;
        Client = client;
        Device = device;
        Device.IssueDescriptoin = issueDescription;
        ReceivedDate = DateTime.Now;
        Status = RepairStatus.Received;
        Servises = new List<Servise>();
        UsedParts = new List<(Part, int)>();
    }

    public void AddServise(Servise servise)
    {
        Servises.Add(servise);
    }

    public void AddPart(Part part, int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("The quantity must be positive");
        try
        {
            part.DecreaseStock(quantity);
            UsedParts.Add((part, quantity));
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException("Failed to add spare part");
        }
    }

    public decimal CalculateTotalCost()
    {
        decimal servicesCost = Servises.Sum(s => s.Price);
        decimal partsCost = UsedParts.Sum(p => p.part.SellingPrice * p.Quantily);
        return servicesCost + partsCost;
    }

    public void ChangeStatus(RepairStatus newStatus)
    {
        if (Status == RepairStatus.Issued && newStatus != RepairStatus.Issued)
            throw new InvalidOperationException("It is not possible to change the status of an issued order.");
                
        if (Status == RepairStatus.Rejected && newStatus != RepairStatus.Rejected)
            throw new InvalidOperationException("It is not possible to change the status of an order with a repair refusal.");
                
        Status = newStatus;
    }
    
    public void CompleteOrder()
    {
        CompletionDate = DateTime.Now;
        Status = RepairStatus.Ready;
    }
 
    public override string ToString()
    {
        return $"Заказ #{Id}: {Client.FullName} - {Device.Brand} {Device.Model} ({Status})";
    }
    
}
