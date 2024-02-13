using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystemTrees;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

public abstract record TreeListOperationResult
{
    private TreeListOperationResult() { }

    public sealed record Success(IRenderableFileSystemUnit Tree) : TreeListOperationResult;

    public sealed record Failed(string Message) : TreeListOperationResult;
}