using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

public abstract record HandleResult
{
    private HandleResult() { }

    public sealed record Success(IFileSystemCommand Command) : HandleResult;

    public sealed record Failed : HandleResult;
}