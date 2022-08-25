namespace DeviceStore.Services.Orders.Contract.Models.Commands;

public record CreateOrderCommand(
    string UserId,
    string DeviceId,
    int Count);
