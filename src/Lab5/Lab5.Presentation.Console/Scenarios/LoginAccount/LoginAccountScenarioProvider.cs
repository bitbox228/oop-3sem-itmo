using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.CurrentUsers;

namespace Lab5.Presentation.Console.Scenarios.LoginAccount;

public class LoginAccountScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _accountService;
    private readonly CurrentUserService _currentUserService;

    public LoginAccountScenarioProvider(IAccountService accountService, CurrentUserService currentUserService)
    {
        _accountService = accountService;
        _currentUserService = currentUserService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new LoginAccountScenario(_accountService);
        return true;
    }
}