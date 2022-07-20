namespace DeviceStore.Services.Warehouse.Contract.Models;

public record DeviceDetailsScrollableCollection(
    ICollection<DeviceDetails>? Collection,
    int Skip,
    int Take);