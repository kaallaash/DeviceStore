namespace DeviceStore.Services.Users.Context.Entities;

public class UserRow
{
    public UserRow(
        string id,
        string login,
        string password,
        string firstName,
        string lastName,
        string phone,
        string email,
        DateTimeOffset dateCreated,
        DateTimeOffset dateUpdated)
    {
        Id = id;
        Login = login;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;
        DateCreated = dateCreated;
        DateUpdated = dateUpdated;
    }

    public string Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateUpdated { get; set; }
}
