namespace DeviceStore.Services.Users.Contract.Models.Commands;

public record UpdateUserCommand(
    string Id,
    string Login,
    string Password,
    string FirstName,
    string LastName,
    string Phone,
    string Email);