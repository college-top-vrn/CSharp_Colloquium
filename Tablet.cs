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
        ScreenSize = screenSize;
    }
    public override string GetDeviceType()
    {
        return DeviceType.ToString();
    }
    public override string ToString()=>
        $"{Brand},{Model},{SerialNumber},{IssueDescription},{DeviceType},{ScreenSize}";

}


