using ElectronicsRepairShop.Core.Persons;

namespace ElectronicsRepairShop.Core.Workshop;

public record RepairOrder
{
    public RepairOrder(string id, Client client, Worker worker, Device device, DateOnly receiveDate)
    {
        Id = Guid.TryParse(id, out var result) ? result : throw new Exception($"Can't parse id {id}");
        Client = client;
        Worker = worker;
        Device = device;
        ReceiveDate = receiveDate;
        CompletionDate = DateOnly.MinValue;
        Status = RepairStatus.Received;
        Services = [];
        UsedParts = [];
        TotalCost = 0;
    }

    public Guid Id { get; }
    public Client Client { get; }
    public Worker Worker { get; }
    public Device Device { get; }
    public DateOnly ReceiveDate { get; }
    public DateOnly CompletionDate { get; init; }
    public RepairStatus Status { get; }
    public HashSet<Service> Services { get; }
    public HashSet<Part> UsedParts { get; }
    public decimal TotalCost { get; init; }
}