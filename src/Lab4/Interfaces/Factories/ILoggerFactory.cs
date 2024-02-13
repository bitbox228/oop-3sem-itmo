using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Factories;

public interface ILoggerFactory
{
    IOutput CreateLogger();
}