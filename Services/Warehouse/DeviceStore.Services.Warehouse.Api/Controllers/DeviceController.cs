using DeviceStore.Services.Warehouse.Contract;
using DeviceStore.Services.Warehouse.Contract.Models;
using DeviceStore.Services.Warehouse.Contract.Models.Commands;

using Microsoft.AspNetCore.Mvc;

namespace DeviceStore.Services.Warehouse.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DeviceController : ControllerBase
{
    private readonly IDevicesService _devicesService;

    public DeviceController(
        IDevicesService devicesService)
    {
        _devicesService = devicesService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DeviceDetails>> Get(
    [FromRoute] GetDeviceDetailsCommand command,
    CancellationToken cancellationToken = default)
    {
        var result = await _devicesService
            .Get(command, cancellationToken)
            //.WithActionResult()
            .ConfigureAwait(false);

        return result;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DeviceDetailsScrollableCollection>> Search(
        [FromRoute] SearchScrollableCollectionCommand command,
        CancellationToken cancellationToken = default)
    {
        var result = await _devicesService
            .Search(command, cancellationToken)
            //.WithActionResult()
            .ConfigureAwait(false);

        return result;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DeviceDetails>> Create(
      [FromBody] CreateDeviceCommand command,
      CancellationToken cancellationToken = default)
    {
        var result = await _devicesService
            .Create(command, cancellationToken)
            //.WithActionResult()
            .ConfigureAwait(false);

        return result;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DeviceDetails>> Add(
        [FromBody] AddDeviceCommand command,
        CancellationToken cancellationToken = default)
    {
        var result = await _devicesService
            .Add(command, cancellationToken)
            //.WithActionResult()
            .ConfigureAwait(false);

        return result;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DeviceDetails>> Subtract(
        [FromBody] SubtractDeviceCommand command,
        CancellationToken cancellationToken = default)
    {
        var result = await _devicesService
            .Subtract(command, cancellationToken)
            //.WithActionResult()
            .ConfigureAwait(false);

        return result;
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> Update(
      [FromBody] UpdateDeviceCommand command,
      CancellationToken cancellationToken = default)
    {
        var result = await _devicesService
            .Update(command, cancellationToken)
            //.WithActionResult()
            .ConfigureAwait(false);

        return result;
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> Delete(
      [FromBody] DeleteDeviceCommand command,
      CancellationToken cancellationToken = default)
    {
        await _devicesService
           .Delete(command, cancellationToken)
           .ConfigureAwait(false);

        return Ok();
    }
}
