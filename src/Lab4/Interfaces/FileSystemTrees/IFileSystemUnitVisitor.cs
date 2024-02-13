using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemTrees;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystemTrees;

public interface IFileSystemUnitVisitor
{
    string Visit(RenderableFileSystemFile file);

    string Visit(RenderableFileSystemDirectory directory);
}