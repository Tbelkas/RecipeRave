﻿namespace Recipe.Api.Models.Requests;

public class RegisterUserModel
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}