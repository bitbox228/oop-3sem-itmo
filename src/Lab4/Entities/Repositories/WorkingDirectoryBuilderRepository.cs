using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Repositories;

public class WorkingDirectoryBuilderRepository : IWorkingDirectoryBuilderRepository
{
    private readonly Dictionary<string, IWorkingDirectoryBuilderFactory> _factories;

    public WorkingDirectoryBuilderRepository()
    {
        _factories = new Dictionary<string, IWorkingDirectoryBuilderFactory>();

        _factories.Add("local", new LocalWorkingDirectoryBuilderFactory());
    }

    public IWorkingDirectoryBuilder? CreateByName(string name)
    {
        KeyValuePair<string, IWorkingDirectoryBuilderFactory> pair =
            _factories.FirstOrDefault(x => x.Key.Equals(name, StringComparison.Ordinal));

        return pair.Equals(default(KeyValuePair<string, IWorkingDirectoryBuilderFactory>))
            ? null
            : pair.Value.CreateWorkingDirectoryBuilder();
    }
}