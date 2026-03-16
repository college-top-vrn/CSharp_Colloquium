namespace ElectronicsRepairShop.Core.Person;

public abstract class APerson()
{
    protected APerson(string id, string name, string surname, string patronymic, string phoneNumber, string email) : this()
    {
        Id = Guid.TryParse(id, out Guid result)
            ? result
            : throw new Exception("Invalid id");
        Name = !Utility.IsEmpty(name) || name.IsWhiteSpace()
            ? name
            : throw new Exception("Name is empty");
        Surname = Utility.IsEmpty(surname) || surname.IsWhiteSpace()
            ? surname
            : throw new Exception("Surname is empty");
        Patronymic = !Utility.IsEmpty(patronymic) || patronymic.IsWhiteSpace()
            ? patronymic
            : "";
        PhoneNumber = !Utility.IsEmpty(phoneNumber) || phoneNumber.IsWhiteSpace()
            ? phoneNumber
            : throw new Exception("Phone number is empty");
        Email = Utility.IsEmpty(email) || email.IsWhiteSpace()
            ? email
            : "";
    }
    
    public new abstract string ToString();

    protected Guid Id { get; }
    protected string Name { get; }
    protected string Surname { get; }
    protected string Patronymic { get; }
    protected string PhoneNumber { get; }
    protected string Email { get; }
}