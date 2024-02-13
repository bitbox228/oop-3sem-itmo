using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystemTrees;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemTrees;

public class RenderableFileSystemDirectory : IRenderableFileSystemUnit
{
    private readonly List<IRenderableFileSystemUnit> _children;

    public RenderableFileSystemDirectory(string name)
    {
        Name = name;
        _children = new List<IRenderableFileSystemUnit>();
    }

    public string Name { get; }
    public IReadOnlyCollection<IRenderableFileSystemUnit> Children => _children;

    public void AddChild(IRenderableFileSystemUnit child)
    {
        _children.Add(child);
    }

    public string Accept(IFileSystemUnitVisitor visitor)
    {
        visitor = visitor ?? throw new ArgumentNullException(nameof(visitor));

        return visitor.Visit(this);
    }
}