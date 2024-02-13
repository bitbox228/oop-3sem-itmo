using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Admins;
using Lab5.Application.CurrentUsers;

namespace Lab5.Presentation.Console.Scenarios.Logout;

public class LogoutScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _accountService;
    private readonly IAdminService _adminService;
    private readonly CurrentUserService _currentUserService;

    public LogoutScenarioProvider(
        IAccountService accountService,
        IAdminService adminService,
        CurrentUserService currentUserService)
    {
        _accountService = accountService;
        _adminService = adminService;
        _currentUserService = currentUserService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new LogoutScenario(_accountService, _adminService, _currentUserService);
        return true;
    }
}