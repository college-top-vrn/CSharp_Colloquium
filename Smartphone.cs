namespace Workshop;
/// <summary>
/// Смартфон
/// </summary>

public class Smartphone : Device
{
    public string OperatingSystem { get; }
    
    
    public Smartphone(int id, string brand, string model, string serialNumber, 
        string issueDescription,DeviceType deviceType, string operatingSystem) 
        : base(id, brand, model, serialNumber, issueDescription,deviceType)
    {
        OperatingSystem = operatingSystem;
    }
    public override string GetDeviceType()
    {
        return DeviceType.ToString();
    }

    public override string ToString()=>
        $"{Brand},{Model},{SerialNumber},{IssueDescription},{DeviceType},{OperatingSystem}";
    
}