using System;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

public class AddresseeFilterProxy : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly int _minImportanceLevel;

    public AddresseeFilterProxy(IAddressee addressee, int minImportanceLevel)
    {
        if (minImportanceLevel < 0) throw new NegativeValueException(nameof(minImportanceLevel));

        _addressee = addressee;
        _minImportanceLevel = minImportanceLevel;
    }

    public void PassMessage(IMessage message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));

        if (_minImportanceLevel <= message.ImportanceLevel)
        {
            _addressee.PassMessage(message);
        }
    }
}