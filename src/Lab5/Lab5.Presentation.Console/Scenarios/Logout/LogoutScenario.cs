using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Admins;
using Lab5.Application.CurrentUsers;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Admins;

namespace Lab5.Presentation.Console.Scenarios.Logout;

public class LogoutScenario : IScenario
{
    private readonly IAccountService _accountService;
    private readonly IAdminService _adminService;
    private readonly CurrentUserService _currentUserService;

    public LogoutScenario(
        IAccountService accountService,
        IAdminService adminService,
        CurrentUserService currentUserService)
    {
        _accountService = accountService;
        _adminService = adminService;
        _currentUserService = currentUserService;
    }

    public string Name => "Logout";

    public Task Run()
    {
        switch (_currentUserService.User)
        {
            case Account:
                _accountService.Logout();
                break;
            case Admin:
                _adminService.Logout();
                break;
        }

        return Task.CompletedTask;
    }
}