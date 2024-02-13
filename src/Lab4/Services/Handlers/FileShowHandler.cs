using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public class FileShowHandler : IFileSystemHandler
{
    private const string FirstKeyWord = "file";
    private const string SecondKeyWord = "show";

    private const int KeyWordsCount = 3;

    private const int FlagsCount = 1;

    public HandleResult Handle(string consoleCommand)
    {
        consoleCommand = consoleCommand ?? throw new ArgumentNullException(nameof(consoleCommand));

        string? path;
        IOutput? logger = new ConsoleOutput();

        string[] splitedCommand = consoleCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries) ??
                                  throw new ArgumentNullException(nameof(consoleCommand));

        if (splitedCommand.Length < KeyWordsCount ||
            !splitedCommand[0].Equals(FirstKeyWord, StringComparison.Ordinal) ||
            !splitedCommand[1].Equals(SecondKeyWord, StringComparison.Ordinal))
        {
            return new HandleResult.Failed();
        }

        path = splitedCommand[2];

        var flagsParser = new FlagsParser();
        FlagsParserResult flagsParserResult = flagsParser.Parse(splitedCommand.Skip(KeyWordsCount).ToArray());

        if (flagsParserResult is FlagsParserResult.Failed)
        {
            return new HandleResult.Failed();
        }

        Dictionary<string, string> flags = ((FlagsParserResult.Success)flagsParserResult).ParsedFlags;

        if (flags.Count > FlagsCount)
        {
            return new HandleResult.Failed();
        }

        if (flags.TryGetValue("-m", out string? value))
        {
            var loggerRepository = new LoggerRepository();
            logger = loggerRepository.CreateByName(value);
        }

        return new HandleResult.Success(
            new FileShowCommand(
                path ?? throw new ArgumentNullException(nameof(consoleCommand)),
                logger ?? throw new ArgumentNullException(nameof(consoleCommand))));
    }
}