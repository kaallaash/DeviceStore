namespace DeviceStore.Services.Orders.Contract.Models.Commands;

public record UpdateOrderCommand(
    string Id,
    string UserId,
    string DeviceId,
    int Count);