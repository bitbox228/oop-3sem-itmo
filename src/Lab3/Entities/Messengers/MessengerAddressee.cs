using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Messenger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public class MessengerAddressee : IAddressee
{
    private readonly IMessenger _messenger;

    public MessengerAddressee(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void PassMessage(IMessage message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));

        _messenger.AddMessage(message.Render());
    }
}