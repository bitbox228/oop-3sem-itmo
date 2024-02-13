using Itmo.ObjectOrientedProgramming.Lab4.Entities.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Factories;

public class ConsoleLoggerFactory : ILoggerFactory
{
    public IOutput CreateLogger()
    {
        return new ConsoleOutput();
    }
}