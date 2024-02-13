using Lab5.Application.CurrentUsers;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Admins;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.ShowInfo;

public class ShowInfoScenario : IScenario
{
    private readonly CurrentUserService _currentUserService;

    public ShowInfoScenario(CurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    public string Name => "Show info";

    public Task Run()
    {
        switch (_currentUserService.User)
        {
            case Account account:
                AnsiConsole.WriteLine("Status: account");
                AnsiConsole.WriteLine($"Login: {account.Login}");
                AnsiConsole.WriteLine($"Balance: {account.Balance}");
                break;
            case Admin admin:
                AnsiConsole.WriteLine("Status: admin");
                AnsiConsole.WriteLine($"Login: {admin.Login}");
                break;
        }

        AnsiConsole.Ask<string>("Ok");
        return Task.CompletedTask;
    }
}