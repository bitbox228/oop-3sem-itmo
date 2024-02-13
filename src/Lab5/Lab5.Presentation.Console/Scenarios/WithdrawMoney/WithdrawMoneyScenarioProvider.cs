using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.CurrentUsers;
using Lab5.Application.Models.Accounts;

namespace Lab5.Presentation.Console.Scenarios.WithdrawMoney;

public class WithdrawMoneyScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _accountService;
    private readonly CurrentUserService _currentUserService;

    public WithdrawMoneyScenarioProvider(IAccountService accountService, CurrentUserService currentUserService)
    {
        _accountService = accountService;
        _currentUserService = currentUserService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is not Account)
        {
            scenario = null;
            return false;
        }

        scenario = new WithdrawMoneyScenario(_accountService);
        return true;
    }
}