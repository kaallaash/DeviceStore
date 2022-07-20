namespace DeviceStore.Services.Warehouse.Contract.Models.Commands;

public record AddDeviceCommand(
    string Id,
    int Count);
