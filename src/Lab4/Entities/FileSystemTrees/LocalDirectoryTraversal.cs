using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystemTrees;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Traversals;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemTrees;

public class LocalDirectoryTraversal : ITraversal
{
    public IRenderableFileSystemUnit Traverse(string path, int depth)
    {
        var directoryInfo = new DirectoryInfo(path);
        var directory = new RenderableFileSystemDirectory(directoryInfo.Name);

        foreach (FileInfo fileInfo in directoryInfo.GetFiles())
        {
            directory.AddChild(new RenderableFileSystemFile(fileInfo.Name));
        }

        foreach (DirectoryInfo tmpDirectoryInfo in directoryInfo.GetDirectories())
        {
            directory.AddChild(depth == 0
                ? new RenderableFileSystemDirectory(tmpDirectoryInfo.Name)
                : Traverse(tmpDirectoryInfo.FullName, depth - 1));
        }

        return directory;
    }
}