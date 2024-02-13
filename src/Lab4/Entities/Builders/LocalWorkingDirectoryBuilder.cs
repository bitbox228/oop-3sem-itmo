using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;

public class LocalWorkingDirectoryBuilder : IWorkingDirectoryBuilder
{
    private string? _address;

    public LocalWorkingDirectoryBuilder() { }

    public IWorkingDirectoryBuilder WithAddress(string address)
    {
        _address = address;
        return this;
    }

    public IWorkingDirectory Build()
    {
        return new LocalWorkingDirectory(_address ?? throw new ArgumentNullException(nameof(_address)));
    }
}