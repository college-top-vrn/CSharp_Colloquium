namespace ElectronicsWorkshop;

public class SmartPhone : Device
{
    public string OperatingSystem { get; set; }
    
    public SmartPhone(int id, string brand, string model, string serialNumber, string issueDescriptoin, string operatingSystem) : base(id, brand, model, serialNumber, issueDescriptoin)
    {
        OperatingSystem = operatingSystem;
    }
    public override string GetDeviceType()
    {
        return "SmartPhone";
    }

    public void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Operating System: {OperatingSystem}");
    }
}