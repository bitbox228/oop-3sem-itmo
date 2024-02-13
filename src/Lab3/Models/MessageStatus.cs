namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public abstract record MessageStatus
{
    private MessageStatus() { }

    public sealed record NotRead : MessageStatus;

    public sealed record Read : MessageStatus;
}