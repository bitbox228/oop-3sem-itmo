using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Messenger;

public interface IMessengerBuilder
{
    IMessenger Build();
}

public interface IMessengerLoggerSelector
{
    IMessengerBuilder WithLogger(ILogger logger);
}