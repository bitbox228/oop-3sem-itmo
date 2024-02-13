using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Factories;

public interface IWorkingDirectoryBuilderFactory
{
    IWorkingDirectoryBuilder CreateWorkingDirectoryBuilder();
}