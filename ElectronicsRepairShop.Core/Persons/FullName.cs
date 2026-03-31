namespace ElectronicsRepairShop.Core.Persons;

public record FullName
{
    public FullName(string name, string surname, string patronymic)
    {
        Name = string.IsNullOrWhiteSpace(name) ? throw new Exception("Invalid name") : name;
        Surname = string.IsNullOrWhiteSpace(surname) ? throw new Exception("Invalid surname") : surname;
        Patronymic = string.IsNullOrWhiteSpace(patronymic) ? string.Empty : patronymic;
    }
    
    public string Name { get; }
    public string Surname { get; }
    public string Patronymic { get; }
}