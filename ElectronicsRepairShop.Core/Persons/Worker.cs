using ElectronicsRepairShop.Core.Workshop;

namespace ElectronicsRepairShop.Core.Persons;

public class Worker(string id, FullName fullName, ContactInformation contactInformation)
    : Person(id, fullName, contactInformation)
{
    public HashSet<Service> Specializations { get; } = [];

    public Service? FindSpecialization(string id)
    {
        var foundSpecialization = Specializations.FirstOrDefault(specialization => specialization.Id.ToString() == id);
        return foundSpecialization;
    }

    public void AddSpecialization(Service service)
    {
        Specializations.Add(service);
    }
    
    public void DeleteSpecialization(string id)
    {
        var deletedQuantity = Specializations.RemoveWhere(specialization => specialization.Id.ToString() == id);
        if (deletedQuantity == 0) throw new Exception($"No such service with id {id}");
    }
}