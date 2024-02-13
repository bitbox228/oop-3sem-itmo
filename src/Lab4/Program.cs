using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ApplicationStates;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        var applicationState = new ApplicationState();
        var parser = new CommandLineParser();

        while (true)
        {
            string? line = Console.ReadLine();
            if (line is null)
            {
                break;
            }

            switch (parser.Parse(line))
            {
                case ParserResult.Success successResult:
                    CommandResult commandResult = successResult.Command.Execute(applicationState);
                    if (commandResult is CommandResult.Failed failedCommandResult)
                    {
                        Console.WriteLine(failedCommandResult.Message);
                    }

                    break;

                case ParserResult.Failed failedResult:
                    Console.WriteLine(failedResult.Message);
                    break;
            }
        }
    }
}