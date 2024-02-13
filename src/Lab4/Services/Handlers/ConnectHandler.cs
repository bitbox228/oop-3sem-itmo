using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public class ConnectHandler : IFileSystemHandler
{
    private const string KeyWord = "connect";

    private const int KeyWordsCount = 2;
    private const int FlagsCount = 1;

    public HandleResult Handle(string consoleCommand)
    {
        consoleCommand = consoleCommand ?? throw new ArgumentNullException(nameof(consoleCommand));

        IFileSystem? fileSystem;
        IWorkingDirectoryBuilder? workingDirectoryBuilder;
        string? address;

        string[] splitedCommand = consoleCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries) ??
                                  throw new ArgumentNullException(nameof(consoleCommand));

        if (splitedCommand.Length < KeyWordsCount ||
            !splitedCommand[0].Equals(KeyWord, StringComparison.Ordinal))
        {
            return new HandleResult.Failed();
        }

        address = splitedCommand[1];

        var flagsParser = new FlagsParser();
        FlagsParserResult flagsParserResult = flagsParser.Parse(splitedCommand.Skip(KeyWordsCount).ToArray());

        if (flagsParserResult is FlagsParserResult.Failed)
        {
            return new HandleResult.Failed();
        }

        Dictionary<string, string> flags = ((FlagsParserResult.Success)flagsParserResult).ParsedFlags;

        if (flags.Count != FlagsCount)
        {
            return new HandleResult.Failed();
        }

        if (flags.TryGetValue("-m", out string? value))
        {
            var fileSystemRepository = new FileSystemRepository();
            var workingDirectoryBuilderRepository = new WorkingDirectoryBuilderRepository();
            fileSystem = fileSystemRepository.CreateByName(value);
            workingDirectoryBuilder = workingDirectoryBuilderRepository.CreateByName(value);
        }
        else
        {
            return new HandleResult.Failed();
        }

        return new HandleResult.Success(
            new ConnectCommand(
                fileSystem ?? throw new ArgumentNullException(nameof(consoleCommand)),
                address ?? throw new ArgumentNullException(nameof(consoleCommand)),
                workingDirectoryBuilder ?? throw new ArgumentNullException(nameof(consoleCommand))));
    }
}