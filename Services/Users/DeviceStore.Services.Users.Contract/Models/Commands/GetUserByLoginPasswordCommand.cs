namespace DeviceStore.Services.Users.Contract.Models.Commands;

public record GetUserByLoginPasswordCommand(
    string Login,
    string Password);