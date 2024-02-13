using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Repositories;

public interface ILoggerRepository
{
    IOutput? CreateByName(string name);
}