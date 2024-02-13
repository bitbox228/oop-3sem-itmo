using System;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class LocalDirectory : IDirectory
{
    public LocalDirectory(string path)
    {
        Path = path;
    }

    public string Path { get; }

    public FileSystemOperationResult MoveFile(IFile file)
    {
        file = file ?? throw new ArgumentNullException(nameof(file));

        return file.Move(Path);
    }

    public FileSystemOperationResult CopyFile(IFile file)
    {
        file = file ?? throw new ArgumentNullException(nameof(file));

        return file.Copy(Path);
    }
}