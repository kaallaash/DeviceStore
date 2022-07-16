namespace DeviceStore.Services.Users.Contract.Models.Commands;

public record CreateUserCommand(
    string Login,
    string Password,
    string FirstName,
    string LastName,
    string Phone,
    string Email);