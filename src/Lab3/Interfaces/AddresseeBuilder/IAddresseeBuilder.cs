using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Messenger;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.User;

namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces.AddresseeBuilder;

public interface IAddresseeBuilder
{
    IAddressee BuildUserAddressee(IUser user);

    IAddressee BuildMessengerAddressee(IMessenger messenger);

    IAddressee BuildDisplayAddressee(IDisplay display);
}

public interface IAddresseeMinImportanceLevelSelector
{
    IAddresseeLoggerSelector WithImportanceLevel(int minImportanceLevel);
}

public interface IAddresseeLoggerSelector
{
    IAddresseeBuilder WithLogger(ILogger logger);
}