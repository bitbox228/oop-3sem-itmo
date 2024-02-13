using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ApplicationStates;

public class ApplicationState
{
    public ApplicationState() { }

    public IWorkingDirectory? WorkingDirectory { get; set; }

    public IFileSystem? FileSystem { get; set; }

    public bool IsConnected => FileSystem is not null && WorkingDirectory is not null;
}