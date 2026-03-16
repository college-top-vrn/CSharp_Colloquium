namespace ElectronicsWorkshop;

public class Tablet : Device
{
    public double ScreenSize { get; set; }
    
    public Tablet(int id, string brand, string model, string serialNumber, string issueDescriptoin, double screenSize) : base(id, brand, model, serialNumber, issueDescriptoin)
    {
        ScreenSize = screenSize;
    }

    public override string GetDeviceType()
    {
        return "Tablet";
    }

    public void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Screen Size: {ScreenSize}");
    }
}