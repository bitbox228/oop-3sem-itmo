using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Repositories;

public interface IWorkingDirectoryBuilderRepository
{
    IWorkingDirectoryBuilder? CreateByName(string name);
}