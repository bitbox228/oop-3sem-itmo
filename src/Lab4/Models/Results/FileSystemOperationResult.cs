namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

public abstract record FileSystemOperationResult
{
    private FileSystemOperationResult() { }

    public sealed record Success : FileSystemOperationResult;

    public sealed record Failed(string Message) : FileSystemOperationResult;
}