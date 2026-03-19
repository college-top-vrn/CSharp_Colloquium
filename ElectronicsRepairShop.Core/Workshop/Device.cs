namespace ElectronicsRepairShop.Core.Workshop;

public abstract class Device
{
    public Device(string id, DeviceType type, string brand, string model, string serialNumber)
    {
        Id = Guid.TryParse(id, out var result) ? result : throw new Exception($"Can't parse id {id}");
        Type = type;
        Brand = brand;
        Model = model;
        SerialNumber = serialNumber;
    }

    public Guid Id { get; }
    public DeviceType Type { get; }
    public string Brand { get; }
    public string Model { get; }
    public string SerialNumber { get; }
}