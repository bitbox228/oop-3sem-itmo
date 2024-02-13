using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public class FileRenameHandler : IFileSystemHandler
{
    private const string FirstKeyWord = "file";
    private const string SecondKeyWord = "rename";

    private const int KeyWordsCount = 4;

    public HandleResult Handle(string consoleCommand)
    {
        consoleCommand = consoleCommand ?? throw new ArgumentNullException(nameof(consoleCommand));

        string? path;
        string? newName;

        string[] splitedCommand = consoleCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries) ??
                                  throw new ArgumentNullException(nameof(consoleCommand));

        if (splitedCommand.Length != KeyWordsCount ||
            !splitedCommand[0].Equals(FirstKeyWord, StringComparison.Ordinal) ||
            !splitedCommand[1].Equals(SecondKeyWord, StringComparison.Ordinal))
        {
            return new HandleResult.Failed();
        }

        path = splitedCommand[2];
        newName = splitedCommand[3];

        return new HandleResult.Success(
            new FileRenameCommand(
                path ?? throw new ArgumentNullException(nameof(consoleCommand)),
                newName ?? throw new ArgumentNullException(nameof(consoleCommand))));
    }
}