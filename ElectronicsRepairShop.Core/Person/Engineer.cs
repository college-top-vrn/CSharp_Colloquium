using ElectronicsRepairShop.Core.Device;

namespace ElectronicsRepairShop.Core.Person;

public class Engineer(string id, string name, string surname, string patronymic, string phoneNumber, string email)
    : APerson(id, name, surname, patronymic, phoneNumber, email)
{
    public override string ToString()
    {
        return $"{Name}, {Surname}, {Patronymic}";
    }

    public void AddRepairableDevice(DeviceType type)
    {
        RepairableDevices.Add(type);
    }

    public bool CanRepair(ADevice device)
    {
        return RepairableDevices.Contains(device.Type);
    }

    private List<DeviceType> RepairableDevices { get; } = [];
}