using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class FlagsParser
{
    public FlagsParserResult Parse(IReadOnlyCollection<string> flags)
    {
        flags = flags ?? throw new ArgumentNullException(nameof(flags));

        if (flags.Count % 2 != 0)
        {
            return new FlagsParserResult.Failed();
        }

        var parsedFlags = new Dictionary<string, string>();

        using IEnumerator<string> enumerator = flags.GetEnumerator();

        for (int i = 0; i < flags.Count / 2; i++)
        {
            enumerator.MoveNext();
            if (!enumerator.Current.StartsWith('-'))
            {
                return new FlagsParserResult.Failed();
            }

            string flagName = enumerator.Current;
            enumerator.MoveNext();
            parsedFlags.Add(flagName, enumerator.Current);
        }

        return new FlagsParserResult.Success(parsedFlags);
    }
}