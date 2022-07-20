namespace DeviceStore.Services.Warehouse.Contract.Models.Commands;

public record CreateDeviceCommand(
    string Name,
    int Count,
    double Price);