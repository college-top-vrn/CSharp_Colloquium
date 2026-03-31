namespace ElectronicsRepairShop.Core.Persons;

public class Client(string id, FullName fullName, ContactInformation contactInformation)
    : Person(id, fullName, contactInformation)
{
}