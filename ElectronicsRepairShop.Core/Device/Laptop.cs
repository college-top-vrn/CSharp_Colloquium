namespace ElectronicsRepairShop.Core.Device;

public class Laptop : ADevice
{
    public Laptop(string id, string brand, string model, string processor) : base(id, DeviceType.Smartphone, brand, model)
    {
        Processor = !Utility.IsEmpty(processor)
            ? processor
            : throw new Exception("Invalid processor");
    }

    public override string ToString()
    {
        return $"{Brand} {Type} {Model} {Processor}";
    }

    private string Processor { get; }
}