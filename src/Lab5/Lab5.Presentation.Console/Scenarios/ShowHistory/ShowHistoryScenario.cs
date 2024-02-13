using System.Globalization;
using Lab5.Application.Contracts.Operations;
using Lab5.Application.Models.Operations;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.ShowHistory;

public class ShowHistoryScenario : IScenario
{
    private readonly IOperationService _operationService;

    public ShowHistoryScenario(IOperationService operationService)
    {
        _operationService = operationService;
    }

    public string Name => "Show history";

    public async Task Run()
    {
        var table = new Table();

        table.AddColumn(new TableColumn("Operations").Centered());

        IAsyncEnumerable<Operation> result = _operationService.ShowHistory();

        await foreach (Operation operation in result)
        {
            table.AddRow((operation.Value >= 0 ? '+' : string.Empty) +
                         operation.Value.ToString(CultureInfo.InvariantCulture));
        }

        AnsiConsole.Write(table);
        AnsiConsole.Ask<string>("Ok");
    }
}