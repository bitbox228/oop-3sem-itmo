using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.DisplayDriver;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Display;

public interface IDisplayBuilder
{
    IDisplay Build();
}

public interface IDisplayDisplayDriverSelector
{
    IDisplayLoggerSelector WithDisplayDriver(IDisplayDriver displayDriver);
}

public interface IDisplayLoggerSelector
{
    IDisplayBuilder WithLogger(ILogger logger);
}