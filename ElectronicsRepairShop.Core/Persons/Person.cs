namespace ElectronicsRepairShop.Core.Persons;

public abstract class Person
{
    public Person(string id, FullName fullName, ContactInformation contactInformation)
    {
        Id = Guid.TryParse(id, out var result) ? result : throw new Exception($"Can't parse id {id}");
        FullName = fullName;
        ContactInformation = contactInformation;
    }

    public Guid Id { get; }
    public FullName FullName { get; }
    public ContactInformation ContactInformation { get; }
}