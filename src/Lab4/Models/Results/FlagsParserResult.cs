using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

public abstract record FlagsParserResult
{
    private FlagsParserResult() { }

    public sealed record Success(Dictionary<string, string> ParsedFlags) : FlagsParserResult;

    public sealed record Failed : FlagsParserResult;
}