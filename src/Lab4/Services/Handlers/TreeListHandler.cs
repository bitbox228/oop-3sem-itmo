using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemTrees;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public class TreeListHandler : IFileSystemHandler
{
    private const string FirstKeyWord = "tree";
    private const string SecondKeyWord = "list";

    private const int KeyWordsCount = 2;
    private const int FlagsCount = 5;

    public HandleResult Handle(string consoleCommand)
    {
        consoleCommand = consoleCommand ?? throw new ArgumentNullException(nameof(consoleCommand));

        IOutput? logger = new ConsoleOutput();
        int depth = 1;
        string fileIcon = "📄";
        string directoryIcon = "📂";
        string margin = "   ";

        string[] splitedCommand = consoleCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries) ??
                                  throw new ArgumentNullException(nameof(consoleCommand));

        if (splitedCommand.Length < KeyWordsCount ||
            !splitedCommand[0].Equals(FirstKeyWord, StringComparison.Ordinal) ||
            !splitedCommand[1].Equals(SecondKeyWord, StringComparison.Ordinal))
        {
            return new HandleResult.Failed();
        }

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

        if (flags.TryGetValue("-m", out string? loggerValue))
        {
            var loggerRepository = new LoggerRepository();
            logger = loggerRepository.CreateByName(loggerValue);
        }

        if (flags.TryGetValue("-d", out string? depthValue))
        {
            if (int.TryParse(depthValue, out int number))
            {
                depth = number;
            }
            else
            {
                return new HandleResult.Failed();
            }
        }

        if (flags.TryGetValue("-fi", out string? fileValue))
        {
            fileIcon = fileValue;
        }

        if (flags.TryGetValue("-di", out string? directoryValue))
        {
            directoryIcon = directoryValue;
        }

        if (flags.TryGetValue("-ma", out string? marginValue))
        {
            margin = marginValue;
        }

        return new HandleResult.Success(
            new TreeListCommand(
                depth,
                new FileSystemUnitVisitor(fileIcon, directoryIcon, margin),
                logger ?? throw new ArgumentNullException(nameof(consoleCommand))));
    }
}