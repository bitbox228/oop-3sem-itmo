using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Admins;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.LoginAdmin;

public class LoginAdminScenario : IScenario
{
    private readonly IAdminService _adminService;

    public LoginAdminScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Login admin";

    public async Task Run()
    {
        string login = AnsiConsole.Ask<string>("Enter your admin login");
        string password = AnsiConsole.Ask<string>("Enter your admin password");

        ServiceResult result = await _adminService.Login(login, password);

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