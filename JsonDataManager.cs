using System.Text.Json;
using ElectronicsWorkshop;

namespace WorkshopManagement
{
    public static class JsonDataManager
    {
        private static readonly string _filePath = "workshop_data.json";

        public static void SaveToFile(WorkShop workshop)
        {
            try
            {
                var data = new WorkShopData.WorkshopData
                {
                    Clients = workshop.Clients,
                    Devices = workshop.Devices,
                    Engineers = workshop.Engineers,
                    Orders = workshop.Orders,
                    Parts = workshop.Parts,
                    Services = workshop.Services
                };
                
                string directory = Path.GetDirectoryName(_filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string json = JsonSerializer.Serialize(data);
                File.WriteAllText(_filePath, json);
                
                Console.WriteLine($"Data saved to {_filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        public static bool LoadFromFile(WorkShop workshop)
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    Console.WriteLine($"File {_filePath} not found");
                    return false;
                }

                string json = File.ReadAllText(_filePath);
                var data = JsonSerializer.Deserialize<WorkShopData.WorkshopData>(json);
                
                if (data == null)
                {
                    Console.WriteLine("No data in file");
                    return false;
                }

                workshop.Clients.Clear();
                workshop.Devices.Clear();
                workshop.Engineers.Clear();
                workshop.Orders.Clear();
                workshop.Parts.Clear();
                workshop.Services.Clear();

                workshop.Clients.AddRange(data.Clients);
                workshop.Devices.AddRange(data.Devices);
                workshop.Engineers.AddRange(data.Engineers);
                workshop.Orders.AddRange(data.Orders);
                workshop.Parts.AddRange(data.Parts);
                workshop.Services.AddRange(data.Services);

                Console.WriteLine($"Data loaded from {_filePath}");
                Console.WriteLine($"Clients: {workshop.Clients.Count}");
                Console.WriteLine($"Orders: {workshop.Orders.Count}");
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                return false;
            }
        }

        public static void ExportOrdersReport(WorkShop workshop)
        {
            try
            {
                string reportPath = "orders_report.json";

                var report = new
                {
                    Generated = DateTime.Now,
                    TotalOrders = workshop.Orders.Count,
                    OrdersByStatus = new Dictionary<string, int>(),
                    TotalRevenue = workshop.Orders
                        .Where(o => o.Status == RepairStatus.Issued)
                        .Sum(o => o.TotalCost),
                    RecentOrders = workshop.Orders
                        .OrderByDescending(o => o.ReceivedDate)
                        .Take(5)
                        .Select(o => new
                        {
                            o.Id,
                            Client = o.Client.FullName,
                            Device = $"{o.Device.Brand} {o.Device.Model}",
                            Status = o.Status.ToString(),
                            Cost = o.TotalCost,
                            Date = o.ReceivedDate.ToString("yyyy-MM-dd")
                        })
                };

                foreach (RepairStatus status in Enum.GetValues(typeof(RepairStatus)))
                {
                    report.OrdersByStatus[status.ToString()] = 
                        workshop.Orders.Count(o => o.Status == status);
                }

                string json = JsonSerializer.Serialize(report);
                File.WriteAllText(reportPath, json);
                
                Console.WriteLine($"Report exported to {reportPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error exporting report: {ex.Message}");
            }
        }
    }
}
