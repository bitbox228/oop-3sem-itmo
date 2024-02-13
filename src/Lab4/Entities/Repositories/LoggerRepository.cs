using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Repositories;

public class LoggerRepository : ILoggerRepository
{
    private readonly Dictionary<string, ILoggerFactory> _factories;

    public LoggerRepository()
    {
        _factories = new Dictionary<string, ILoggerFactory>();

        _factories.Add("console", new ConsoleLoggerFactory());
    }

    public IOutput? CreateByName(string name)
    {
        KeyValuePair<string, ILoggerFactory> pair =
            _factories.FirstOrDefault(x => x.Key.Equals(name, StringComparison.Ordinal));

        return pair.Equals(default(KeyValuePair<string, ILoggerFactory>))
            ? null
            : pair.Value.CreateLogger();
    }
}