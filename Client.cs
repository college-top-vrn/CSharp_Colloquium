namespace ElectronicsWorkshop;

public class Client
{
   public int Id  { get; set; }
   public string FullName { get; set; }
   public string Phone { get; set; }
   public string Email { get; set; }

   public Client(int id, string fullName, string phone)
   {
      Id = id;
      FullName = fullName;
      Phone = phone;
   }

   public override string ToString()
   {
      return $"{FullName} phone: {Phone}";
   }
}