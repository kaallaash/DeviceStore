﻿namespace DeviceStore.Services.Users.Contract.Models;

public record UserDetails(
    string Id,
    string FirstName,
    string LastName,
    string Phone,
    string Email);