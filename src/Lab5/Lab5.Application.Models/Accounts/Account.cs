using Lab5.Application.Models.Users;

namespace Lab5.Application.Models.Accounts;

public record Account(string Login, string Password, long Balance) : UserBase(Login, Password);