using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public class DisconnectHandler : IFileSystemHandler
{
    private const string KeyWord = "disconnect";

    private const int KeyWordsCount = 1;

    public HandleResult Handle(string consoleCommand)
    {
        consoleCommand = consoleCommand ?? throw new ArgumentNullException(nameof(consoleCommand));

        string[] splitedCommand = consoleCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries) ??
                                  throw new ArgumentNullException(nameof(consoleCommand));

        if (splitedCommand.Length != KeyWordsCount ||
            !splitedCommand[0].Equals(KeyWord, StringComparison.Ordinal))
        {
            return new HandleResult.Failed();
        }

        return new HandleResult.Success(new DisconnectCommand());
    }
}