using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Operations;
using Lab5.Application.CurrentUsers;
using Lab5.Application.Models.Accounts;

namespace Lab5.Presentation.Console.Scenarios.ShowHistory;

public class ShowHistoryScenarioProvider : IScenarioProvider
{
    private readonly IOperationService _operationService;
    private readonly CurrentUserService _currentUserService;

    public ShowHistoryScenarioProvider(CurrentUserService currentUserService, IOperationService operationService)
    {
        _currentUserService = currentUserService;
        _operationService = operationService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is not Account)
        {
            scenario = null;
            return false;
        }

        scenario = new ShowHistoryScenario(_operationService);
        return true;
    }
}