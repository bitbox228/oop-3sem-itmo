using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class CommandLineParser
{
    private readonly List<IFileSystemHandler> _handlers;

    public CommandLineParser()
    {
        _handlers = new List<IFileSystemHandler>
        {
            new ConnectHandler(),
            new DisconnectHandler(),
            new FileCopyHandler(),
            new FileDeleteHandler(),
            new FileMoveHandler(),
            new FileRenameHandler(),
            new FileShowHandler(),
            new TreeGotoHandler(),
            new TreeListHandler(),
        };
    }

    public ParserResult Parse(string consoleCommand)
    {
        foreach (HandleResult handleResult in _handlers.Select(handler => handler.Handle(consoleCommand)))
        {
            if (handleResult is HandleResult.Success successResult)
            {
                return new ParserResult.Success(successResult.Command);
            }
        }

        return new ParserResult.Failed("Invalid command.");
    }
}