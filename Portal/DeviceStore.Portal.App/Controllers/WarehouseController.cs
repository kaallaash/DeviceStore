using DeviceStore.Portal.App.ViewModels;
using DeviceStore.Services.Warehouse.Contract;
using DeviceStore.Services.Warehouse.Contract.Models;
using DeviceStore.Services.Warehouse.Contract.Models.Commands;

using Microsoft.AspNetCore.Mvc;

namespace DeviceStore.Portal.App.Controllers;

public class WarehouseController : Controller
{
    private readonly IDevicesService _devicesService;
    //private readonly UserManager<User> _userManager;
    //private readonly SignInManager<User> _signInManager;

    public WarehouseController(
        //UserManager<User> userManager,
        //SignInManager<User> signInManager,
        IDevicesService devicesService
        )
    {
        _devicesService = devicesService;
        //_userManager = userManager;
        //_signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Get(
        SearchScrollableCollectionCommand command,
        CancellationToken cancellationToken = default)
    {
        if (command.Skip == 0 && command.Take == 0)
        {
            command = new SearchScrollableCollectionCommand(0, 10);
        }

        var devices = _devicesService
            .Search(command, cancellationToken)
            .Result;

        var viewModel = new List<DeviceViewModel>();

        if (devices != null && devices.Collection != null)
        {
            foreach (var device in devices.Collection)
            {
                viewModel.Add(MapToDto(device));
            }
        }

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult GetById(
    GetDeviceDetailsCommand command,
    CancellationToken cancellationToken = default)
    {
        var device = _devicesService
            .Get(command, cancellationToken)
            .Result;

        return View(MapToDto(device));
    }

    private static DeviceViewModel MapToDto(DeviceDetails device)
    {
        return new DeviceViewModel(
            device.Id,
            device.Name,
            device.Count,
            device.Price);
    }
}
