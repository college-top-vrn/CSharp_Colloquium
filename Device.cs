namespace ElectronicsWorkshop;

public abstract class Device
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public string IssueDescriptoin { get; set; }
    
    protected Device(int id, string brand, string model, string serialNumber, string issueDescriptoin)
    {
        Id = id;
        Brand = brand;
        Model = model;
        SerialNumber = serialNumber;
        IssueDescriptoin = issueDescriptoin;
    }
    
    public abstract string GetDeviceType();

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Device: {GetDeviceType()}");
        Console.WriteLine($"Brand: {Brand}");
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"Serial Number: {SerialNumber}");
        Console.WriteLine($"Issue Descriptoin: {IssueDescriptoin}");
    }
    
}