using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Repositories;

public interface IFileSystemRepository
{
    IFileSystem? CreateByName(string name);
}