using Lab5.Presentation.Console.Scenarios;
using Lab5.Presentation.Console.Scenarios.DepositMoney;
using Lab5.Presentation.Console.Scenarios.LoginAccount;
using Lab5.Presentation.Console.Scenarios.LoginAdmin;
using Lab5.Presentation.Console.Scenarios.Logout;
using Lab5.Presentation.Console.Scenarios.RegisterAccount;
using Lab5.Presentation.Console.Scenarios.ShowHistory;
using Lab5.Presentation.Console.Scenarios.ShowInfo;
using Lab5.Presentation.Console.Scenarios.WithdrawMoney;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LoginAdminScenarioProvider>();
        collection.AddScoped<IScenarioProvider, RegisterAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ShowInfoScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DepositMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ShowHistoryScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutScenarioProvider>();

        return collection;
    }
}