using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Messenger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public class Messenger : IMessenger
{
    private const string MessengerPrefix = "Messenger";

    private readonly List<string> _messages;
    private readonly ILogger _logger;

    public Messenger(ILogger logger)
    {
        _messages = new List<string>();
        _logger = logger;
    }

    public static IMessengerLoggerSelector Builder => new MessengerBuilder();

    public void AddMessage(string message)
    {
        _messages.Add(message);
    }

    public void WriteMessages()
    {
        _logger.Output(MessengerPrefix);
        _logger.Output("\n");

        foreach (string message in _messages)
        {
            _logger.Output(message);

            _logger.Output("\n");
        }
    }

    private class MessengerBuilder : IMessengerBuilder, IMessengerLoggerSelector
    {
        private ILogger? _logger;

        public MessengerBuilder()
        {
            _logger = null;
        }

        public IMessengerBuilder WithLogger(ILogger logger)
        {
            _logger = logger;
            return this;
        }

        public IMessenger Build()
        {
            return new Messenger(_logger ?? throw new ArgumentNullException(nameof(_logger)));
        }
    }
}