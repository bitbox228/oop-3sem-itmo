using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ApplicationStates;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class ConnectCommand : IFileSystemCommand
{
    private readonly IFileSystem _fileSystem;
    private readonly IWorkingDirectoryBuilder _workingDirectoryBuilder;
    private readonly string _address;

    public ConnectCommand(
        IFileSystem fileSystem,
        string address,
        IWorkingDirectoryBuilder workingDirectoryBuilder)
    {
        _fileSystem = fileSystem;
        _address = address;
        _workingDirectoryBuilder = workingDirectoryBuilder;
    }

    public CommandResult Execute(ApplicationState applicationState)
    {
        applicationState = applicationState ?? throw new ArgumentNullException(nameof(applicationState));

        applicationState.FileSystem = _fileSystem;

        if (!applicationState.FileSystem.CanConnect(_address))
        {
            return new CommandResult.Failed("Can't connect to FileSystem.");
        }

        _workingDirectoryBuilder.WithAddress(_address);
        applicationState.WorkingDirectory = _workingDirectoryBuilder.Build();

        return new CommandResult.Success();
    }
}