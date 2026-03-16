namespace ElectronicsWorkshop;

public class Laptop : Device
{
    public string Processor { get; set; }
    
    public Laptop(int id, string brand, string model, string serialNumber, string issueDescriptoin, string processor) : base(id, brand, model, serialNumber, issueDescriptoin)
    {
        Processor = processor;
    }

    public override string GetDeviceType()
    {
        return "Laptop";
    }
    
    public void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Processor: {Processor}");
    }
}