using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystems;

public interface IFileSystem
{
    bool CanConnect(string address);

    FileSystemOperationResult TreeGoto(IWorkingDirectory workingDirectory, string path);

    TreeListOperationResult TreeList(IWorkingDirectory workingDirectory, int depth);

    FileShowOperationResult FileShow(IWorkingDirectory workingDirectory, string path);

    FileSystemOperationResult FileMove(IWorkingDirectory workingDirectory, string sourcePath, string destinationPath);

    FileSystemOperationResult FileCopy(IWorkingDirectory workingDirectory, string sourcePath, string destinationPath);

    FileSystemOperationResult FileDelete(IWorkingDirectory workingDirectory, string path);

    FileSystemOperationResult FileRename(IWorkingDirectory workingDirectory, string path, string name);
}