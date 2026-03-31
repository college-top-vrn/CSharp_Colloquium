namespace ElectronicsRepairShop.Core.Workshop;

public class RepairOrderService
{
    public void ChangeRepairStatus(RepairOrder order, RepairStatus status)
    {
        order.Status = status;
    }

    public void FinishRepair(RepairOrder order)
    {
        order.Status = RepairStatus.Ready;
        order.CompletionDate = DateOnly.FromDateTime(DateTime.Now);
        order.TotalCost = order.Services.Select(service => service.Price).Sum() +
                          order.UsedParts.Select(usedPart => usedPart.SellingPrice).Sum();
    }
}