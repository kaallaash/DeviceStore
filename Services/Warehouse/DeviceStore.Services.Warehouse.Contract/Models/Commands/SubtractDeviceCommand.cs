namespace DeviceStore.Services.Warehouse.Contract.Models.Commands;

public record SubtractDeviceCommand(
    string Id,
    int count);