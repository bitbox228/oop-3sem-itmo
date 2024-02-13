using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.WithdrawMoney;

public class WithdrawMoneyScenario : IScenario
{
    private readonly IAccountService _accountService;

    public WithdrawMoneyScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Withdraw money";

    public async Task Run()
    {
        long money = AnsiConsole.Ask<long>("Enter money to withdraw");

        ServiceResult result = await _accountService.WithdrawMoney(money);

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