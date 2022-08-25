namespace DeviceStore.Services.Orders.Context.Entities;

public class OrderRow
{
    public OrderRow(
        string id,
        string userId,
        string deviceId,
        int count,
        DateTimeOffset dateCreated)
    {
        Id = id;
        UserId = userId;
        DeviceId = deviceId;
        Count = count;
        DateCreated = dateCreated;
    }

    public string Id { get; set; }
    public string UserId { get; set; }
    public string DeviceId { get; set; }
    public int Count { get; set; }
    public DateTimeOffset DateCreated { get; set; }
}