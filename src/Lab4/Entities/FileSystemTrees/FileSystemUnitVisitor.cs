using System;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystemTrees;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemTrees;

public class FileSystemUnitVisitor : IFileSystemUnitVisitor
{
    private readonly string _fileIcon;
    private readonly string _directoryIcon;
    private readonly string _margin;

    public FileSystemUnitVisitor(
        string fileIcon,
        string directoryIcon,
        string margin)
    {
        _fileIcon = fileIcon;
        _directoryIcon = directoryIcon;
        _margin = margin;
    }

    public string Visit(RenderableFileSystemFile file)
    {
        file = file ?? throw new ArgumentNullException(nameof(file));

        return _fileIcon + ' ' + file.Name;
    }

    public string Visit(RenderableFileSystemDirectory directory)
    {
        directory = directory ?? throw new ArgumentNullException(nameof(directory));

        var stringBuilder = new StringBuilder();

        stringBuilder.Append(_directoryIcon + ' ' + directory.Name + "\n");

        foreach (IRenderableFileSystemUnit fileSystemUnit in directory.Children)
        {
            stringBuilder.Append(_margin + string
                .Join("\n" + _margin, fileSystemUnit
                    .Accept(this)
                    .Split('\n', StringSplitOptions.RemoveEmptyEntries)));
            stringBuilder.Append('\n');
        }

        return stringBuilder.ToString();
    }
}