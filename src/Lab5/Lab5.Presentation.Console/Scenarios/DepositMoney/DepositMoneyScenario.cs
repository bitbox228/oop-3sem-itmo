using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.DepositMoney;

public class DepositMoneyScenario : IScenario
{
    private readonly IAccountService _accountService;

    public DepositMoneyScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Deposit money";

    public async Task Run()
    {
        long money = AnsiConsole.Ask<long>("Enter money to deposit");

        ServiceResult result = await _accountService.DepositMoney(money);

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