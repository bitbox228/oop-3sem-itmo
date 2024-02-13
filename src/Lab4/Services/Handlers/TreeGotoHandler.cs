using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public class TreeGotoHandler : IFileSystemHandler
{
    private const string FirstKeyWord = "tree";
    private const string SecondKeyWord = "goto";

    private const int KeyWordsCount = 3;

    public HandleResult Handle(string consoleCommand)
    {
        consoleCommand = consoleCommand ?? throw new ArgumentNullException(nameof(consoleCommand));

        string? path;

        string[] splitedCommand = consoleCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries) ??
                                  throw new ArgumentNullException(nameof(consoleCommand));

        if (splitedCommand.Length != KeyWordsCount ||
            !splitedCommand[0].Equals(FirstKeyWord, StringComparison.Ordinal) ||
            !splitedCommand[1].Equals(SecondKeyWord, StringComparison.Ordinal))
        {
            return new HandleResult.Failed();
        }

        path = splitedCommand[2];

        return new HandleResult.Success(
            new TreeGotoCommand(
                path ?? throw new ArgumentNullException(nameof(consoleCommand))));
    }
}