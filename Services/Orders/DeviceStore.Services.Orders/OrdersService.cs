using DeviceStore.Services.Orders.Context;
using DeviceStore.Services.Orders.Context.Entities;
using DeviceStore.Services.Orders.Contract;
using DeviceStore.Services.Orders.Contract.Models;
using DeviceStore.Services.Orders.Contract.Models.Commands;

using Microsoft.EntityFrameworkCore;

using NUlid;

namespace DeviceStore.Services.Orders;

public class OrdersService : IOrdersService
{
    private readonly OrdersDbContext _dbContext;

    public OrdersService(
        OrdersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Order> Get(
        GetOrderCommand command,
        CancellationToken cancellationToken = default)
    {
        var row = await _dbContext.Orders
            .AsNoTracking()
            .SingleOrDefaultAsync(
                r => r.Id == command.Id,
                cancellationToken)
            .ConfigureAwait(false);

        if (row == null)
        {
            throw new InvalidOperationException($"The order by Id = {command.Id} is not found");
        }

        return MapToDto(row);
    }

    public async Task<List<Order>> GetOrders(
        GetOrdersCommand command,
        CancellationToken cancellationToken = default)
    {
        var rows = await _dbContext.Orders
            .AsNoTracking()
            .Where(
                r => r.UserId == command.UserId)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        if (rows == null)
        {
            throw new InvalidOperationException($"The order by UserId = {command.UserId} is not found");
        }

        var orderList = new List<Order>();

        foreach (var row in rows)
        {
            orderList.Add(MapToDto(row));
        }

        return orderList;
    }

    public async Task<Order> Create(
        CreateOrderCommand command,
        CancellationToken cancellationToken = default)
    {
        var row = new OrderRow(
            Ulid.NewUlid().ToString(),
            command.UserId,
            command.DeviceId,
            command.Count,
            DateTimeOffset.UtcNow);

        await _dbContext.Orders
            .AddAsync(row, cancellationToken)
            .ConfigureAwait(false);

        await _dbContext
            .SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);

        return MapToDto(row);
    }

    public async Task<string> Update(
        UpdateOrderCommand command,
        CancellationToken cancellationToken = default)
    {
        var row = await _dbContext.Orders
           .AsNoTracking()
           .SingleOrDefaultAsync(
               r => r.Id == command.Id,
               cancellationToken)
           .ConfigureAwait(false);

        if (row == null)
        {
            throw new InvalidOperationException($"The order by id = {command.Id} is not found");
        }

        if (command.Count == 0)
        {
            return await Delete(new DeleteOrderCommand(command.Id), cancellationToken);
        }

        row.DeviceId = command.DeviceId;
        row.Count = command.Count;

        _dbContext.Orders.Update(row);

        await _dbContext
            .SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);

        return row.Id;
    }

    public async Task<string> Delete(
        DeleteOrderCommand command,
        CancellationToken cancellationToken = default)
    {
        var row = await _dbContext.Orders
               .AsNoTracking()
               .SingleOrDefaultAsync(
                   t => t.Id == command.Id,
                   cancellationToken)
               .ConfigureAwait(false);

        if (row != null)
        {
            _dbContext.Orders.Remove(row);

            await _dbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        return command.Id;
    }

    private static Order MapToDto(OrderRow row)
    {
        return new Order(
            row.Id,
            row.UserId,
            row.DeviceId,
            row.Count);
    }
}