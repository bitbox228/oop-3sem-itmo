using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Admins;
using Lab5.Application.CurrentUsers;

namespace Lab5.Presentation.Console.Scenarios.LoginAdmin;

public class LoginAdminScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly CurrentUserService _currentUserService;

    public LoginAdminScenarioProvider(IAdminService adminService, CurrentUserService currentUserService)
    {
        _adminService = adminService;
        _currentUserService = currentUserService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new LoginAdminScenario(_adminService);
        return true;
    }
}