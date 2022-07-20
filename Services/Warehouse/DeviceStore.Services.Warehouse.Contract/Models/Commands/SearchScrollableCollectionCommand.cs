namespace DeviceStore.Services.Warehouse.Contract.Models.Commands;

public record SearchScrollableCollectionCommand(
    int Skip,
    int Take);
