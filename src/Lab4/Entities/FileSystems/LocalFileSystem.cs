using System;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemTrees;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class LocalFileSystem : IFileSystem
{
    private const string DirectoryMessage = "Invalid path to directory.";
    private const string FileMessage = "Invalid path to file.";

    public bool CanConnect(string address)
    {
        return Directory.Exists(address);
    }

    public FileSystemOperationResult TreeGoto(IWorkingDirectory workingDirectory, string path)
    {
        workingDirectory = workingDirectory ?? throw new ArgumentNullException(nameof(workingDirectory));

        string pathToDirectory;

        if (Directory.Exists(path)) pathToDirectory = path;
        else if (Directory.Exists(workingDirectory.Path + path)) pathToDirectory = workingDirectory.Path + path;
        else return new FileSystemOperationResult.Failed(DirectoryMessage);

        workingDirectory.Path = pathToDirectory;

        if (workingDirectory.Path.Last() != '/')
        {
            workingDirectory.Path += '/';
        }

        return new FileSystemOperationResult.Success();
    }

    public TreeListOperationResult TreeList(IWorkingDirectory workingDirectory, int depth)
    {
        workingDirectory = workingDirectory ?? throw new ArgumentNullException(nameof(workingDirectory));

        if (depth < 0) return new TreeListOperationResult.Failed("Depth can't be negative.");

        var traversal = new LocalDirectoryTraversal();

        return new TreeListOperationResult.Success(traversal.Traverse(workingDirectory.Path, depth));
    }

    public FileShowOperationResult FileShow(IWorkingDirectory workingDirectory, string path)
    {
        workingDirectory = workingDirectory ?? throw new ArgumentNullException(nameof(workingDirectory));

        string pathToFile;

        if (File.Exists(path)) pathToFile = path;
        else if (File.Exists(workingDirectory.Path + path)) pathToFile = workingDirectory.Path + path;
        else return new FileShowOperationResult.Failed(FileMessage);

        var file = new LocalFile(pathToFile);
        return file.Show();
    }

    public FileSystemOperationResult FileMove(
        IWorkingDirectory workingDirectory,
        string sourcePath,
        string destinationPath)
    {
        workingDirectory = workingDirectory ?? throw new ArgumentNullException(nameof(workingDirectory));

        string pathToFile;
        string pathToDirectory;

        if (File.Exists(sourcePath)) pathToFile = sourcePath;
        else if (File.Exists(workingDirectory.Path + sourcePath)) pathToFile = workingDirectory.Path + sourcePath;
        else return new FileSystemOperationResult.Failed(FileMessage);

        if (Directory.Exists(destinationPath)) pathToDirectory = destinationPath;
        else if (Directory.Exists(workingDirectory.Path + destinationPath))
            pathToDirectory = workingDirectory.Path + destinationPath;
        else return new FileSystemOperationResult.Failed(DirectoryMessage);

        if (pathToDirectory.Last() != '/')
        {
            pathToDirectory += '/';
        }

        var directory = new LocalDirectory(pathToDirectory);
        var file = new LocalFile(pathToFile);

        return directory.MoveFile(file);
    }

    public FileSystemOperationResult FileCopy(
        IWorkingDirectory workingDirectory,
        string sourcePath,
        string destinationPath)
    {
        workingDirectory = workingDirectory ?? throw new ArgumentNullException(nameof(workingDirectory));

        string pathToFile;
        string pathToDirectory;

        if (File.Exists(sourcePath)) pathToFile = sourcePath;
        else if (File.Exists(workingDirectory.Path + sourcePath)) pathToFile = workingDirectory.Path + sourcePath;
        else return new FileSystemOperationResult.Failed(FileMessage);

        if (Directory.Exists(destinationPath)) pathToDirectory = destinationPath;
        else if (Directory.Exists(workingDirectory.Path + destinationPath))
            pathToDirectory = workingDirectory.Path + destinationPath;
        else return new FileSystemOperationResult.Failed(DirectoryMessage);

        if (pathToDirectory.Last() != '/')
        {
            pathToDirectory += '/';
        }

        var directory = new LocalDirectory(pathToDirectory);
        var file = new LocalFile(pathToFile);

        return directory.CopyFile(file);
    }

    public FileSystemOperationResult FileDelete(IWorkingDirectory workingDirectory, string path)
    {
        workingDirectory = workingDirectory ?? throw new ArgumentNullException(nameof(workingDirectory));

        string pathToFile;

        if (File.Exists(path)) pathToFile = path;
        else if (File.Exists(workingDirectory.Path + path)) pathToFile = workingDirectory.Path + path;
        else return new FileSystemOperationResult.Failed(FileMessage);

        var file = new LocalFile(pathToFile);

        return file.Delete();
    }

    public FileSystemOperationResult FileRename(IWorkingDirectory workingDirectory, string path, string name)
    {
        workingDirectory = workingDirectory ?? throw new ArgumentNullException(nameof(workingDirectory));

        string pathToFile;

        if (File.Exists(path)) pathToFile = path;
        else if (File.Exists(workingDirectory.Path + path)) pathToFile = workingDirectory.Path + path;
        else return new FileSystemOperationResult.Failed(FileMessage);

        var file = new LocalFile(pathToFile);

        return file.Rename(name);
    }
}