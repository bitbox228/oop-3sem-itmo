using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ApplicationStates;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileRenameCommand : IFileSystemCommand
{
    private readonly string _path;
    private readonly string _newName;

    public FileRenameCommand(string path, string newName)
    {
        _path = path;
        _newName = newName;
    }

    public CommandResult Execute(ApplicationState applicationState)
    {
        applicationState = applicationState ?? throw new ArgumentNullException(nameof(applicationState));

        if (applicationState.FileSystem is null || applicationState.WorkingDirectory is null)
        {
            return new CommandResult.Failed("Application is not connected.");
        }

        FileSystemOperationResult operationResult =
            applicationState.FileSystem.FileRename(applicationState.WorkingDirectory, _path, _newName);

        return operationResult switch
        {
            FileSystemOperationResult.Failed failedResult => new CommandResult.Failed(failedResult.Message),
            FileSystemOperationResult.Success => new CommandResult.Success(),
            _ => throw new ArgumentOutOfRangeException(nameof(applicationState)),
        };
    }
}