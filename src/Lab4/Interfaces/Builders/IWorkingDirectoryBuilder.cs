using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Builders;

public interface IWorkingDirectoryBuilder
{
    IWorkingDirectoryBuilder WithAddress(string address);

    IWorkingDirectory Build();
}