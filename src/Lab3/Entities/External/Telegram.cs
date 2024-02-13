using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Telegram;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.External;

public class Telegram : ITelegram
{
    public void SendMessage(string apiKey, long userId, string message)
    {
        Console.WriteLine("[Telegram] " + message);
    }
}