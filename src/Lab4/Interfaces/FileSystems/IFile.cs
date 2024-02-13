using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystems;

public interface IFile
{
    string Path { get; }

    string FileName { get; }

    FileSystemOperationResult Move(string newPath);

    FileSystemOperationResult Copy(string newPath);

    FileSystemOperationResult Rename(string newName);

    FileSystemOperationResult Delete();

    FileShowOperationResult Show();
}