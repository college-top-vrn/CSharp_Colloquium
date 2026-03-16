namespace ElectronicsRepairShop.Core.Person;

public class Client(string id, string name, string surname, string patronymic, string phoneNumber, string email)
    : APerson(id, name, surname, patronymic, phoneNumber, email)
{
    public override string ToString()
    {
        return $"{Name} {Surname} {PhoneNumber}";
    }
}