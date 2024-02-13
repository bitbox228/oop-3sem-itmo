using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ApplicationStates;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemTrees;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystemTrees;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class TreeListCommand : IFileSystemCommand
{
    private readonly int _depth;
    private readonly IFileSystemUnitVisitor _visitor;
    private readonly IOutput _output;

    public TreeListCommand(int depth, IFileSystemUnitVisitor visitor, IOutput output)
    {
        _depth = depth;
        _visitor = visitor;
        _output = output;
    }

    public CommandResult Execute(ApplicationState applicationState)
    {
        applicationState = applicationState ?? throw new ArgumentNullException(nameof(applicationState));

        if (applicationState.FileSystem is null || applicationState.WorkingDirectory is null)
        {
            return new CommandResult.Failed("Application is not connected.");
        }

        TreeListOperationResult operationResult =
            applicationState.FileSystem.TreeList(applicationState.WorkingDirectory, _depth);

        if (operationResult is TreeListOperationResult.Failed failed)
        {
            return new CommandResult.Failed(failed.Message);
        }

        var tree = new RenderableFileSystemTree(((TreeListOperationResult.Success)operationResult).Tree, _visitor);
        _output.Print(tree.Render());

        return new CommandResult.Success();
    }
}