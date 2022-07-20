namespace DeviceStore.Services.Warehouse.Context.Entities;

public class DeviceRow
{
    public DeviceRow(
        string id,
        string name,
        int count,
        double price,
        DateTimeOffset dateCreated,
        DateTimeOffset dateUpdated)
    {
        Id = id;
        Name = name;
        Count = count;
        Price = price;
        DateCreated = dateCreated;
        DateUpdated = dateUpdated;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public int Count { get; set; }
    public double Price { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateUpdated { get; set; }
}
