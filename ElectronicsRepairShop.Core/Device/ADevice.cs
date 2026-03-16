namespace ElectronicsRepairShop.Core.Device;

public abstract class ADevice
{
    protected ADevice(string id, DeviceType type, string brand, string model)
    {
        Type = type;
        Id = Guid.TryParse(id, out Guid result)
            ? result
            : throw new Exception("Invalid id");
        Brand = !Utility.IsEmpty(brand)
            ? brand
            : throw new Exception("Invalid brand");
        Model = !Utility.IsEmpty(model)
            ? model
            : throw new Exception("Invalid model");
    }

    public abstract string ToString();

    public Guid Id { get; }
    public DeviceType Type { get; }
    public string Brand { get; }
    public string Model { get; }
}