using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces.User;

public interface IUser
{
    void ReceiveMessage(IMessage message);

    void MarkMessageAsRead(int id);

    MessageStatus GetMessageStatusById(int id);
}