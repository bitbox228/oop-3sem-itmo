using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.RegisterAccount;

public class RegisterAccountScenario : IScenario
{
    private readonly IAccountService _accountService;

    public RegisterAccountScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Register account";

    public async Task Run()
    {
        string login = AnsiConsole.Ask<string>("Enter your account login");
        string password = AnsiConsole.Ask<string>("Enter your account password");

        ServiceResult result = await _accountService.Register(login, password);

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