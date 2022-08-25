namespace DeviceStore.Services.Orders.Contract.Models.Commands;

public record UpdateOrderCommand(
    string Id,
    string DeviceId,
    int Count);