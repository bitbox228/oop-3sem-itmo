using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ApplicationStates;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileShowCommand : IFileSystemCommand
{
    private readonly string _path;
    private readonly IOutput _output;

    public FileShowCommand(string path, IOutput output)
    {
        _path = path;
        _output = output;
    }

    public CommandResult Execute(ApplicationState applicationState)
    {
        applicationState = applicationState ?? throw new ArgumentNullException(nameof(applicationState));

        if (applicationState.FileSystem is null || applicationState.WorkingDirectory is null)
        {
            return new CommandResult.Failed("Application is not connected.");
        }

        FileShowOperationResult operationResult =
            applicationState.FileSystem.FileShow(applicationState.WorkingDirectory, _path);

        if (operationResult is FileShowOperationResult.Failed failed)
        {
            return new CommandResult.Failed(failed.Message);
        }

        _output.Print(((FileShowOperationResult.Success)operationResult).FileContents.Content);

        return new CommandResult.Success();
    }
}