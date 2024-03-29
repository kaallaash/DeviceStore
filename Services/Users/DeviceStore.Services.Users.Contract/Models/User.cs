﻿namespace DeviceStore.Services.Users.Contract.Models;

public record User(
    string Id,
    string Login,
    string Password,
    string FirstName,
    string LastName,
    string Phone,
    string Email);