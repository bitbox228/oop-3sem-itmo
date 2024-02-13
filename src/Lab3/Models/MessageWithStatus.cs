using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public record MessageWithStatus
{
    public MessageWithStatus(IMessage message, MessageStatus messageStatus)
    {
        Message = message;
        MessageStatus = messageStatus;
    }

    public IMessage Message { get; set; }

    public MessageStatus MessageStatus { get; set; }
}