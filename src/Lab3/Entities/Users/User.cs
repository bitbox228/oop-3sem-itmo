using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.User;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

public class User : IUser
{
    private readonly Dictionary<int, MessageWithStatus> _messages;

    private int _messagesCount;

    public User(string name)
    {
        Name = name;
        _messagesCount = 0;
        _messages = new Dictionary<int, MessageWithStatus>();
    }

    public static IUserNameSelector Builder => new UserBuilder();

    public string Name { get; }

    public void ReceiveMessage(IMessage message)
    {
        _messagesCount += 1;
        _messages.Add(_messagesCount, new MessageWithStatus(message, new MessageStatus.NotRead()));
    }

    public void MarkMessageAsRead(int id)
    {
        KeyValuePair<int, MessageWithStatus> result = _messages.FirstOrDefault(pair => pair.Key == id);

        if (result.Equals(default(KeyValuePair<int, MessageWithStatus>)))
        {
            throw new NonExistentMessageException(id);
        }

        if (result.Value.MessageStatus is MessageStatus.Read)
        {
            throw new AlreadyReadMessageException(id);
        }

        _messages[result.Key].MessageStatus = new MessageStatus.Read();
    }

    public MessageStatus GetMessageStatusById(int id)
    {
        KeyValuePair<int, MessageWithStatus> result = _messages.FirstOrDefault(pair => pair.Key == id);

        if (result.Equals(default(KeyValuePair<int, MessageWithStatus>)))
        {
            throw new NonExistentMessageException(id);
        }

        return result.Value.MessageStatus;
    }

    private class UserBuilder : IUserBuilder, IUserNameSelector
    {
        private string? _name;

        public UserBuilder()
        {
            _name = null;
        }

        public IUserBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public IUser Build()
        {
            return new User(_name ?? throw new ArgumentNullException(nameof(_name)));
        }
    }
}