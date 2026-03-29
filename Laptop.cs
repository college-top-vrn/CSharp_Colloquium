namespace Workshop;
/// <summary>
/// Ноутбук
/// </summary>
public class Laptop : Device
{
    public string Processor { get;  }

    
    public Laptop(int id, string brand, string model, string serialNumber, 
        string issueDescription,DeviceType deviceType, string processor) 
        : base(id, brand, model, serialNumber, issueDescription, deviceType)
    {
        Processor = processor;
    }
    public override string GetDeviceType()
    {
        return DeviceType.ToString();
    }

    public override string ToString() => 
        $"{Brand},{Model},{SerialNumber},{IssueDescription},{DeviceType},{Processor}";
}