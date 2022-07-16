using DeviceStore.Services.Users.Contract;
using DeviceStore.Services.Users.Contract.Models;
using DeviceStore.Services.Users.Contract.Models.Commands;

using Microsoft.AspNetCore.Mvc;

namespace DeviceStore.Services.Users.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UserController(
        IUsersService userService)
    {
        _usersService = userService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserDetails>> Get(
    [FromRoute] GetUserCommand command,
    CancellationToken cancellationToken = default)
    {
        var result = await _usersService
            .Get(command, cancellationToken)
            //.WithActionResult()
            .ConfigureAwait(false);

        return result;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> Create(
      [FromBody] CreateUserCommand command,
      CancellationToken cancellationToken = default)
    {
        var result = await _usersService
            .Create(command, cancellationToken)
            //.WithActionResult()
            .ConfigureAwait(false);

        return result;
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> Update(
      [FromBody] UpdateUserCommand command,
      CancellationToken cancellationToken = default)
    {
        var result = await _usersService
            .Update(command, cancellationToken)
            //.WithActionResult()
            .ConfigureAwait(false);

        return result;
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> Delete(
      [FromBody] DeleteUserCommand command,
      CancellationToken cancellationToken = default)
    {
        await _usersService
           .Delete(command, cancellationToken)
           .ConfigureAwait(false);

        return Ok();
    }
}
