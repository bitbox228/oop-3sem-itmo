using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Renderables;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class LocalFile : IFile
{
    private const string ErrorMessage = "Non-existent file";

    public LocalFile(string path)
    {
        Path = path;
        FileName = new FileInfo(path).Name;
        IsExist = true;
    }

    public string Path { get; private set; }
    public string FileName { get; private set; }
    public bool IsExist { get; private set; }

    public FileSystemOperationResult Move(string newPath)
    {
        if (!IsExist) return new FileSystemOperationResult.Failed(ErrorMessage);

        try
        {
            File.Move(Path, newPath + FileName);
        }
        catch (IOException e)
        {
            return new FileSystemOperationResult.Failed(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            return new FileSystemOperationResult.Failed(e.Message);
        }

        Path = newPath + FileName;
        return new FileSystemOperationResult.Success();
    }

    public FileSystemOperationResult Copy(string newPath)
    {
        if (!IsExist) return new FileSystemOperationResult.Failed(ErrorMessage);

        try
        {
            File.Copy(Path, newPath + FileName);
        }
        catch (IOException e)
        {
            return new FileSystemOperationResult.Failed(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            return new FileSystemOperationResult.Failed(e.Message);
        }

        return new FileSystemOperationResult.Success();
    }

    public FileSystemOperationResult Rename(string newName)
    {
        if (!IsExist) return new FileSystemOperationResult.Failed(ErrorMessage);

        FileName = newName;
        string newPath = new FileInfo(Path).DirectoryName + '/';

        return Move(newPath);
    }

    public FileSystemOperationResult Delete()
    {
        if (!IsExist) return new FileSystemOperationResult.Failed(ErrorMessage);

        try
        {
            File.Delete(Path);
        }
        catch (IOException e)
        {
            return new FileSystemOperationResult.Failed(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            return new FileSystemOperationResult.Failed(e.Message);
        }

        IsExist = false;
        return new FileSystemOperationResult.Success();
    }

    public FileShowOperationResult Show()
    {
        if (!IsExist) return new FileShowOperationResult.Failed(ErrorMessage);

        string fileContent;

        try
        {
            fileContent = File.ReadAllText(Path);
        }
        catch (IOException e)
        {
            return new FileShowOperationResult.Failed(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            return new FileShowOperationResult.Failed(e.Message);
        }

        return new FileShowOperationResult.Success(new FileContents(fileContent));
    }
}