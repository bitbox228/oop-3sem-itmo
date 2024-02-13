using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class DisplayAddressee : IAddressee
{
    private readonly IDisplay _display;

    public DisplayAddressee(IDisplay display)
    {
        _display = display;
    }

    public void PassMessage(IMessage message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));

        _display.SaveMessage(message.Render());
    }
}