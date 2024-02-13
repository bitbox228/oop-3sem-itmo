using Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Factories;

public class LocalWorkingDirectoryBuilderFactory : IWorkingDirectoryBuilderFactory
{
    public IWorkingDirectoryBuilder CreateWorkingDirectoryBuilder()
    {
        return new LocalWorkingDirectoryBuilder();
    }
}