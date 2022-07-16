using DeviceStore.Services.Users.Context;
using DeviceStore.Services.Users.Context.Entities;
using DeviceStore.Services.Users.Contract;
using DeviceStore.Services.Users.Contract.Models;
using DeviceStore.Services.Users.Contract.Models.Commands;

using Microsoft.EntityFrameworkCore;

using NUlid;

namespace DeviceStore.Services.Users;

public class UsersService : IUsersService
{
    private readonly UsersDbContext _dbContext;

    public UsersService(
        UsersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserDetails> Get(
        GetUserCommand command,
        CancellationToken cancellationToken = default)
    {
        var row = await _dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(
                r => r.Id == command.Id,
                cancellationToken)
            .ConfigureAwait(false);

        if (row == null)
        {
            throw new InvalidOperationException($"The user by id = {command.Id} is not found");
        }

        return MapToDto(row);
    }

    public async Task<string> Create(
        CreateUserCommand command,
        CancellationToken cancellationToken = default)
    {
        var row = new UserRow(
            Ulid.NewUlid().ToString(),
            command.Login,
            command.Password,
            command.FirstName,
            command.LastName,
            command.Phone,
            command.Email,
            DateTimeOffset.UtcNow,
            DateTimeOffset.UtcNow);

        await _dbContext.Users
            .AddAsync(row, cancellationToken)
            .ConfigureAwait(false);

        await _dbContext
            .SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);

        return row.Id;
    }

    public async Task<string> Update(
        UpdateUserCommand command,
        CancellationToken cancellationToken = default)
    {
        var row = await _dbContext.Users
           .AsNoTracking()
           .SingleOrDefaultAsync(
               r => r.Id == command.Id,
               cancellationToken)
           .ConfigureAwait(false);

        if (row == null)
        {
            throw new InvalidOperationException($"The user by id = {command.Id} is not found");
        }

        row.FirstName = command.FirstName;
        row.LastName = command.LastName;
        row.Phone = command.Phone;
        row.Email = command.Email;
        row.Login = command.Login;
        row.Password = command.Password;
        row.DateUpdated = DateTimeOffset.UtcNow;

        _dbContext.Users.Update(row);

        await _dbContext
            .SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);

        return row.Id;
    }

    public async Task<string> Delete(
        DeleteUserCommand command,
        CancellationToken cancellationToken = default)
    {
        var row = await _dbContext.Users
               .AsNoTracking()
               .SingleOrDefaultAsync(
                   t => t.Id == command.Id,
                   cancellationToken)
               .ConfigureAwait(false);

        if (row != null)
        {
            _dbContext.Users.Remove(row);

            await _dbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        return command.Id;
    }

    private static UserDetails MapToDto(UserRow row)
    {
        return new UserDetails(
            row.Id,
            row.FirstName,
            row.LastName,
            row.Phone,
            row.Email);
    }
}