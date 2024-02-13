using System;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystemTrees;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemTrees;

public class RenderableFileSystemFile : IRenderableFileSystemUnit
{
    public RenderableFileSystemFile(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public string Accept(IFileSystemUnitVisitor visitor)
    {
        visitor = visitor ?? throw new ArgumentNullException(nameof(visitor));

        return visitor.Visit(this);
    }
}