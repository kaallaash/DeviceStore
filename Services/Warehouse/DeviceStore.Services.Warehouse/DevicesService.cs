using DeviceStore.Services.Warehouse.Context;
using DeviceStore.Services.Warehouse.Context.Entities;
using DeviceStore.Services.Warehouse.Contract;
using DeviceStore.Services.Warehouse.Contract.Models;
using DeviceStore.Services.Warehouse.Contract.Models.Commands;

using Microsoft.EntityFrameworkCore;
using NUlid;

namespace DeviceStore.Services.Warehouse;

public class DevicesService : IDevicesService
{
    private readonly WarehouseDbContext _dbContext;

    public DevicesService(WarehouseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<DeviceDetails> Get(
        GetDeviceDetailsCommand command,
        CancellationToken cancellationToken = default)
    {
        var row = await _dbContext.Devices
            .FirstOrDefaultAsync(
                r => r.Id == command.Id,
                cancellationToken)
            .ConfigureAwait(false);

        if (row == null)
        {
            throw new InvalidOperationException($"The device by id = {command.Id} is not found");
        }

        return MapToDto(row);
    }

    public async Task<DeviceDetailsScrollableCollection> Search(
      SearchScrollableCollectionCommand command,
      CancellationToken cancellationToken = default)
    {
        var rows = await _dbContext.Devices
            .AsNoTracking()
            .Skip(command.Skip)
            .Take(command.Take)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        var details = new List<DeviceDetails>();

        foreach (var row in rows)
        {
            details.Add(MapToDto(row));
        }

        return new DeviceDetailsScrollableCollection(
            details,
            command.Skip,
            command.Take);
    }

    public async Task<DeviceDetails> Create(
        CreateDeviceCommand command,
        CancellationToken cancellationToken = default)
    {
        var row = new DeviceRow(
            Ulid.NewUlid().ToString(),
            command.Name,
            command.Count,
            command.Price,
            DateTimeOffset.UtcNow,
            DateTimeOffset.UtcNow);

        await _dbContext.Devices
            .AddAsync(row, cancellationToken)
            .ConfigureAwait(false);

        await _dbContext
            .SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);

        
        return MapToDto(row);
    }

    public async Task<DeviceDetails> Add(
    AddDeviceCommand command,
    CancellationToken cancellationToken = default)
    {
        var row = await _dbContext.Devices
            .AsNoTracking()
            .SingleOrDefaultAsync(
                r => r.Id == command.Id,
                cancellationToken)
            .ConfigureAwait(false);

        if (row == null)
        {
            throw new InvalidOperationException($"The user by id = {command.Id} is not found");
        }

        row.Count += command.Count;
        row.DateUpdated = DateTimeOffset.UtcNow;

        _dbContext.Devices.Update(row);

        await _dbContext
            .SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);

        return MapToDto(row);
    }

    public async Task<DeviceDetails> Subtract(
        SubtractDeviceCommand command,
        CancellationToken cancellationToken = default)
    {
        var row = await _dbContext.Devices
            .AsNoTracking()
            .SingleOrDefaultAsync(
                r => r.Id == command.Id,
                cancellationToken)
            .ConfigureAwait(false);

        if (row == null)
        {
            throw new InvalidOperationException($"The user by id = {command.Id} is not found");
        }

        row.Count -= command.Count;
        row.DateUpdated = DateTimeOffset.UtcNow;

        _dbContext.Devices.Update(row);

        await _dbContext
            .SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);

        return MapToDto(row);
    }

    public async Task<string> Update(
        UpdateDeviceCommand command,
        CancellationToken cancellationToken = default)
    {
        var row = await _dbContext.Devices
           .AsNoTracking()
           .SingleOrDefaultAsync(
               r => r.Id == command.Id,
               cancellationToken)
           .ConfigureAwait(false);

        if (row == null)
        {
            throw new InvalidOperationException($"The user by id = {command.Id} is not found");
        }

        row.Name = command.Name;
        row.Price = command.Price;
        row.DateUpdated = DateTimeOffset.UtcNow;

        _dbContext.Devices.Update(row);

        await _dbContext
            .SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);

        return row.Id;
    }

    public async Task<string> Delete(
        DeleteDeviceCommand command,
        CancellationToken cancellationToken = default)
    {
        var row = await _dbContext.Devices
               .AsNoTracking()
               .SingleOrDefaultAsync(
                   t => t.Id == command.Id,
                   cancellationToken)
               .ConfigureAwait(false);

        if (row != null)
        {
            _dbContext.Devices.Remove(row);

            await _dbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        return command.Id;
    }

    private static DeviceDetails MapToDto(DeviceRow row)
    {
        return new DeviceDetails(
            row.Id,
            row.Name,
            row.Count,
            row.Price);
    }
}
