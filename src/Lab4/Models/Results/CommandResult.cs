namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

public abstract record CommandResult
{
    private CommandResult() { }

    public sealed record Success : CommandResult;

    public sealed record Failed(string Message) : CommandResult;
}