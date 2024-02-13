using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystemTrees;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Traversals;

public interface ITraversal
{
    IRenderableFileSystemUnit Traverse(string path, int depth);
}