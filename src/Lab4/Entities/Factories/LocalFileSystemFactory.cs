using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Factories;

public class LocalFileSystemFactory : IFileSystemFactory
{
    public LocalFileSystemFactory() { }

    public IFileSystem CreateFileSystem()
    {
        return new LocalFileSystem();
    }
}