namespace DeviceStore.Services.Orders.Contract.Models;

public record Order(
    string Id,
    string UserId,
    string DeviceId,
    int Count);