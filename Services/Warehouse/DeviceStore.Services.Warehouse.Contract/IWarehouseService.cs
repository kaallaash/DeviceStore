using DeviceStore.Services.Warehouse.Contract.Models;
using DeviceStore.Services.Warehouse.Contract.Models.Commands;

namespace DeviceStore.Services.Warehouse.Contract;

public interface IWarehouseService
{
    Task<DeviceDetails> Get(
        GetDeviceDetailsCommand command,
        CancellationToken cancellationToken = default);

    Task<DeviceDetailsScrollableCollection> Search(
        SearchScrollableCollectionCommand command,
        CancellationToken cancellationToken = default);

    Task<DeviceDetails> Create(
        CreateDeviceCommand command,
        CancellationToken cancellationToken = default);

    Task<DeviceDetails> Add(
        AddDeviceCommand command,
        CancellationToken cancellationToken = default);

    Task<string> Update(
        UpdateDeviceCommand command,
        CancellationToken cancellationToken = default);

    Task<DeviceDetails> Subtract(
        SubtractDeviceCommand command,
        CancellationToken cancellationToken = default);

    Task<string> Delete(
        DeleteDeviceCommand command,
        CancellationToken cancellationToken = default);
}
