using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.User;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

public class UserAddressee : IAddressee
{
    private readonly IUser _user;

    public UserAddressee(IUser user)
    {
        _user = user;
    }

    public void PassMessage(IMessage message)
    {
        _user.ReceiveMessage(message);
    }
}