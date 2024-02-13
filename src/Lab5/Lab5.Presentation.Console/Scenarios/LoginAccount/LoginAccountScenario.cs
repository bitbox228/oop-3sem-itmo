using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.LoginAccount;

public class LoginAccountScenario : IScenario
{
    private readonly IAccountService _accountService;

    public LoginAccountScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Login account";

    public async Task Run()
    {
        string login = AnsiConsole.Ask<string>("Enter your account login");
        string password = AnsiConsole.Ask<string>("Enter your account password");

        ServiceResult result = await _accountService.Login(login, password);

        string message = result switch
        {
            ServiceResult.Success => "Success",
            ServiceResult.Failed failedResult => failedResult.Message,
            _ => "Unknown error",
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}