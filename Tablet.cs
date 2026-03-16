namespace Workshop;
/// <summary>
/// Планшет
/// </summary>
public class Tablet:Device
{
    public double ScreenSize {get;}
    
    public Tablet(int id, string brand, string model, string serialNumber, 
        string issueDescription, DeviceType deviceType,double screenSize) 
        : base(id, brand, model, serialNumber, issueDescription,deviceType)
    {
        ScreenSize = screenSize > 0 
            ? screenSize 
            : throw new ArgumentException("Размер экрана должен быть положительным");
    }
    public override string GetDeviceType()
    {
        return DeviceType.ToString();
    }
    public override string PrintInfo()=>
        $"{Brand}, {Model}, {SerialNumber}, {IssueDescription}, {DeviceType} {ScreenSize}";

}


