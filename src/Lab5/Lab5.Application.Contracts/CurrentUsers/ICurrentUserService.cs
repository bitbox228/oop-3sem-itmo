using Lab5.Application.Models.Users;

namespace Lab5.Application.Contracts.CurrentUsers;

public interface ICurrentUserService
{
    UserBase? User { get; }
}