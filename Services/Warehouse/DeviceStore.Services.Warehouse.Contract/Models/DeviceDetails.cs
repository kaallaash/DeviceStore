namespace DeviceStore.Services.Warehouse.Contract.Models;
   
public record DeviceDetails(
    string Id,
    string Name,
    int Count,
    double Price);