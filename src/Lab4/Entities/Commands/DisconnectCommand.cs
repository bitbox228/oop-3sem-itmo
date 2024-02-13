using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ApplicationStates;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class DisconnectCommand : IFileSystemCommand
{
    public DisconnectCommand() { }

    public CommandResult Execute(ApplicationState applicationState)
    {
        applicationState = applicationState ?? throw new ArgumentNullException(nameof(applicationState));

        if (!applicationState.IsConnected)
        {
            return new CommandResult.Failed("Application is already disconnected.");
        }

        applicationState.FileSystem = null;
        applicationState.WorkingDirectory = null;

        return new CommandResult.Success();
    }
}