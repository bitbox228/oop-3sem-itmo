using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public class FileCopyHandler : IFileSystemHandler
{
    private const string FirstKeyWord = "file";
    private const string SecondKeyWord = "copy";

    private const int KeyWordsCount = 4;

    public HandleResult Handle(string consoleCommand)
    {
        consoleCommand = consoleCommand ?? throw new ArgumentNullException(nameof(consoleCommand));

        string? sourcePath;
        string? destinationPath;

        string[] splitedCommand = consoleCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries) ??
                                  throw new ArgumentNullException(nameof(consoleCommand));

        if (splitedCommand.Length != KeyWordsCount ||
            !splitedCommand[0].Equals(FirstKeyWord, StringComparison.Ordinal) ||
            !splitedCommand[1].Equals(SecondKeyWord, StringComparison.Ordinal))
        {
            return new HandleResult.Failed();
        }

        sourcePath = splitedCommand[2];
        destinationPath = splitedCommand[3];

        return new HandleResult.Success(
            new FileCopyCommand(
                sourcePath ?? throw new ArgumentNullException(nameof(consoleCommand)),
                destinationPath ?? throw new ArgumentNullException(nameof(consoleCommand))));
    }
}