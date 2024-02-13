using Itmo.ObjectOrientedProgramming.Lab4.Entities.Renderables;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

public abstract record FileShowOperationResult
{
    private FileShowOperationResult() { }

    public sealed record Success(FileContents FileContents) : FileShowOperationResult;

    public sealed record Failed(string Message) : FileShowOperationResult;
}