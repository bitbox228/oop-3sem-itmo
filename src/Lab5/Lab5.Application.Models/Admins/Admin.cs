using Lab5.Application.Models.Users;

namespace Lab5.Application.Models.Admins;

public record Admin(string Login, string Password) : UserBase(Login, Password);