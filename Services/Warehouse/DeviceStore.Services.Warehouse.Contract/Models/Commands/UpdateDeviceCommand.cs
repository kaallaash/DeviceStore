namespace DeviceStore.Services.Warehouse.Contract.Models.Commands;

public record UpdateDeviceCommand(
    string Id,
    string Name,
    double Price);