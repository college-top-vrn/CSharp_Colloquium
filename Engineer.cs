namespace ElectronicsWorkshop;

public class Engineer
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public List<DeviceType> Specializations { get; set; }

    public Engineer(int id, string fullName, List<DeviceType> specializations)
    {
        Id = id;
        FullName = fullName;
        Specializations = specializations;
    }

    public bool CanRepair(Device device)
    {
        DeviceType deviceType;
    
        if (device is Laptop)
            deviceType = DeviceType.Laptop;
        else if (device is SmartPhone)
            deviceType = DeviceType.Smartphone;
        else if (device is Tablet)
            deviceType = DeviceType.Tablet;
        else
            throw new ArgumentException($"Unknow type");
    
        return Specializations.Contains(deviceType);
    }

    public override string ToString()
    {
        return $"{FullName}, {Specializations}";
    }
}