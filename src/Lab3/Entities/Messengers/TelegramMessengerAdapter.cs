using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Messenger;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Telegram;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public class TelegramMessengerAdapter : IMessenger
{
    private const string TelegramMessengerPrefix = "Messenger";

    private readonly List<string> _messages;
    private readonly ILogger _logger;

    private readonly ITelegram _telegram;
    private readonly string _apiKey;
    private readonly long _userId;

    public TelegramMessengerAdapter(
        ITelegram telegram,
        string apiKey,
        long userId,
        ILogger logger)
    {
        _telegram = telegram;
        _apiKey = apiKey;
        _userId = userId;
        _logger = logger;

        _messages = new List<string>();
    }

    public void AddMessage(string message)
    {
        _telegram.SendMessage(_apiKey, _userId, message);

        _messages.Add(message);
    }

    public void WriteMessages()
    {
        _logger.Output(TelegramMessengerPrefix);
        _logger.Output("\n");

        foreach (string message in _messages)
        {
            _logger.Output(message);

            _logger.Output("\n");
        }
    }
}