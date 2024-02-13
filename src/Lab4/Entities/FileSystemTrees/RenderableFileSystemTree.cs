using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystemTrees;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemTrees;

public class RenderableFileSystemTree : IRenderable
{
    private readonly IRenderableFileSystemUnit _root;
    private readonly IFileSystemUnitVisitor _visitor;

    public RenderableFileSystemTree(IRenderableFileSystemUnit root, IFileSystemUnitVisitor visitor)
    {
        _root = root;
        _visitor = visitor;
    }

    public string Render()
    {
        return _root.Accept(_visitor);
    }
}