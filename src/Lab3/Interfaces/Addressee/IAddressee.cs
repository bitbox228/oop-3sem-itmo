using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Addressee;

public interface IAddressee
{
    void PassMessage(IMessage message);
}