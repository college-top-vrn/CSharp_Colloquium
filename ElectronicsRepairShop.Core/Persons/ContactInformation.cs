namespace ElectronicsRepairShop.Core.Persons;

public record ContactInformation
{
    public ContactInformation(string phoneNumber, string email)
    {
        PhoneNumber = string.IsNullOrWhiteSpace(phoneNumber) ? throw new Exception("Invalid phone number") : phoneNumber;
        Email = string.IsNullOrWhiteSpace(email) ? string.Empty : email;
    }
    
    public string PhoneNumber { get; }
    public string Email { get; }
}