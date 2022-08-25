using DeviceStore.Services.Orders.Contract.Models;
using DeviceStore.Services.Orders.Contract.Models.Commands;

namespace DeviceStore.Services.Orders.Contract;

public interface IOrdersService
{
    Task<Order> Get(
        GetOrderCommand command,
        CancellationToken cancellationToken = default);

    Task<List<Order>> GetOrders(
    GetOrdersCommand command,
    CancellationToken cancellationToken = default);

    Task<Order> Create(
        CreateOrderCommand command,
        CancellationToken cancellationToken = default);

    Task<string> Update(
        UpdateOrderCommand command,
        CancellationToken cancellationToken = default);

    Task<string> Delete(
        DeleteOrderCommand command,
        CancellationToken cancellationToken = default);
}
