using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Repositories;

public class FileSystemRepository : IFileSystemRepository
{
    private readonly Dictionary<string, IFileSystemFactory> _factories;

    public FileSystemRepository()
    {
        _factories = new Dictionary<string, IFileSystemFactory>();

        _factories.Add("local", new LocalFileSystemFactory());
    }

    public IFileSystem? CreateByName(string name)
    {
        KeyValuePair<string, IFileSystemFactory> pair =
            _factories.FirstOrDefault(x => x.Key.Equals(name, StringComparison.Ordinal));

        return pair.Equals(default(KeyValuePair<string, IFileSystemFactory>))
            ? null
            : pair.Value.CreateFileSystem();
    }
}