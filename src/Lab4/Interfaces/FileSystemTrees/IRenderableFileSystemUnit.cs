namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystemTrees;

public interface IRenderableFileSystemUnit
{
    string Accept(IFileSystemUnitVisitor visitor);
}