using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Factories;

public interface IFileSystemFactory
{
    IFileSystem CreateFileSystem();
}