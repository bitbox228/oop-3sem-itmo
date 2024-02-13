using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ApplicationStates;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileMoveCommand : IFileSystemCommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public FileMoveCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public CommandResult Execute(ApplicationState applicationState)
    {
        applicationState = applicationState ?? throw new ArgumentNullException(nameof(applicationState));

        if (applicationState.FileSystem is null || applicationState.WorkingDirectory is null)
        {
            return new CommandResult.Failed("Application is not connected.");
        }

        FileSystemOperationResult operationResult =
            applicationState.FileSystem.FileMove(applicationState.WorkingDirectory, _sourcePath, _destinationPath);

        return operationResult switch
        {
            FileSystemOperationResult.Failed failedResult => new CommandResult.Failed(failedResult.Message),
            FileSystemOperationResult.Success => new CommandResult.Success(),
            _ => throw new ArgumentOutOfRangeException(nameof(applicationState)),
        };
    }
}