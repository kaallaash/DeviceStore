using DeviceStore.Services.Users.Contract.Models;
using DeviceStore.Services.Users.Contract.Models.Commands;

namespace DeviceStore.Services.Users.Contract;

public interface IUsersService
{
    Task<UserDetails> Get(
        GetUserCommand command,
        CancellationToken cancellationToken = default);

    Task<string> Create(
        CreateUserCommand command,
        CancellationToken cancellationToken = default);

    Task<string> Update(
        UpdateUserCommand command,
        CancellationToken cancellationToken = default);

    Task<string> Delete(
        DeleteUserCommand command,
        CancellationToken cancellationToken = default);
}
