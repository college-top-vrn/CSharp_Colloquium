namespace ElectronicsWorkshop;

public class Servise
{
    public int Id { set;get; }
    public string Name { set; get; }
    public decimal Price { set; get; }

    public Servise(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name}, {Price}";
    }
}