using System.Diagnostics.CodeAnalysis;
using Lab5.Application.CurrentUsers;

namespace Lab5.Presentation.Console.Scenarios.ShowInfo;

public class ShowInfoScenarioProvider : IScenarioProvider
{
    private readonly CurrentUserService _currentUserService;

    public ShowInfoScenarioProvider(CurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new ShowInfoScenario(_currentUserService);
        return true;
    }
}