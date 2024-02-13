using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.AddresseeBuilder;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Messenger;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.User;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

public class AddresseeBuilder :
    IAddresseeMinImportanceLevelSelector,
    IAddresseeLoggerSelector,
    IAddresseeBuilder
{
    private int _minImportanceLevel;
    private ILogger? _logger;

    public AddresseeBuilder()
    {
        _minImportanceLevel = 0;
        _logger = null;
    }

    public IAddresseeLoggerSelector WithImportanceLevel(int minImportanceLevel)
    {
        _minImportanceLevel = minImportanceLevel;
        return this;
    }

    public IAddresseeBuilder WithLogger(ILogger logger)
    {
        _logger = logger;
        return this;
    }

    public IAddressee BuildUserAddressee(IUser user)
    {
        return new AddresseeFilterProxy(
            new AddresseeLoggerDecorator(
                new UserAddressee(user),
                _logger ?? throw new ArgumentNullException(nameof(user))),
            _minImportanceLevel);
    }

    public IAddressee BuildMessengerAddressee(IMessenger messenger)
    {
        return new AddresseeFilterProxy(
            new AddresseeLoggerDecorator(
                new MessengerAddressee(messenger),
                _logger ?? throw new ArgumentNullException(nameof(messenger))),
            _minImportanceLevel);
    }

    public IAddressee BuildDisplayAddressee(IDisplay display)
    {
        return new AddresseeFilterProxy(
            new AddresseeLoggerDecorator(
                new DisplayAddressee(display),
                _logger ?? throw new ArgumentNullException(nameof(display))),
            _minImportanceLevel);
    }
}