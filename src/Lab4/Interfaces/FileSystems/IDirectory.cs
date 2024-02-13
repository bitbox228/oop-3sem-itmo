using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystems;

public interface IDirectory
{
    string Path { get; }

    FileSystemOperationResult MoveFile(IFile file);

    FileSystemOperationResult CopyFile(IFile file);
}