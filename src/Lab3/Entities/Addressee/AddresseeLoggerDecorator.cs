using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

public class AddresseeLoggerDecorator : IAddressee
{
    private const string LogMessage = "Logged message.";

    private readonly IAddressee _addressee;
    private readonly ILogger _logger;

    public AddresseeLoggerDecorator(IAddressee addressee, ILogger logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

    public void PassMessage(IMessage message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));

        _logger.Output(LogMessage);
        _addressee.PassMessage(message);
    }
}