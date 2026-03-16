namespace ElectronicsWorkshop;

public class WorkShopData
{
    [Serializable]
    public class WorkshopData
    {
        public List<Client> Clients { get; set; }
        public List<Device> Devices { get; set; }
        public List<Engineer> Engineers { get; set; }
        public List<RepairOrder> Orders { get; set; }
        public List<Part> Parts { get; set; }
        public List<Servise> Services { get; set; }

        public WorkshopData()
        {
            Clients = new List<Client>();
            Devices = new List<Device>();
            Engineers = new List<Engineer>();
            Orders = new List<RepairOrder>();
            Parts = new List<Part>();
            Services = new List<Servise>();
        }
    }
}