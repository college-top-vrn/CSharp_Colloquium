namespace ElectronicsRepairShop.Core.Device;

public class Smartphone : ADevice
{
    public Smartphone(string id, string brand, string model, string operatingSystem) : base(id, DeviceType.Laptop, brand, model)
    {
        OperatingSystem = !Utility.IsEmpty(operatingSystem)
            ? operatingSystem
            : throw new Exception("Operating system");
    }

    public override string ToString()
    {
        return $"{Brand} {Type} {Model} {OperatingSystem}";
    }

    private string OperatingSystem { get; }
}