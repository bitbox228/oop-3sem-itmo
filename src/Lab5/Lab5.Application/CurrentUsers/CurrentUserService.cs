using Lab5.Application.Contracts.CurrentUsers;
using Lab5.Application.Models.Users;

namespace Lab5.Application.CurrentUsers;

public class CurrentUserService : ICurrentUserService
{
    public UserBase? User { get; set; }
}