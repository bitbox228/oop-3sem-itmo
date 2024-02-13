using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

public abstract record ParserResult
{
    private ParserResult() { }

    public sealed record Success(IFileSystemCommand Command) : ParserResult;

    public sealed record Failed(string Message) : ParserResult;
}