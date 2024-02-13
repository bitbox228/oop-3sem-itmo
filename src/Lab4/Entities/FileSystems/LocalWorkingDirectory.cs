using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class LocalWorkingDirectory : IWorkingDirectory
{
    public LocalWorkingDirectory(string path)
    {
        Path = path;
        if (Path.Last() != '/')
        {
            Path += '/';
        }
    }

    public string Path { get; set; }
}