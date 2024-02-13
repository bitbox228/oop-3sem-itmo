using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Messenger;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.User;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessagesTest
{
    [Fact]
    public void UnreadMessageUserTest()
    {
        // Arrange
        IUser user = User.Builder
            .WithName("Nikita")
            .Build();

        int messageId = 1;
        IMessage message = new Message(
            "Hello!",
            "How are you?",
            5);

        string topicName = "UserNikitaTopic";
        Topic topic = Topic.Builder
            .WithName(topicName)
            .WithAddressee(new AddresseeBuilder()
                .WithImportanceLevel(5)
                .WithLogger(new ConsoleLogger())
                .BuildUserAddressee(user))
            .Build();

        var messageSender = new MessageSender();
        messageSender.AddTopic(topic);

        MessageStatus result;

        // Act
        messageSender.SendMessageToTopic(topicName, message);
        result = user.GetMessageStatusById(messageId);

        // Assert
        Assert.IsType<MessageStatus.NotRead>(result);
    }

    [Fact]
    public void ReadMessageUserTest()
    {
        // Arrange
        IUser user = User.Builder
            .WithName("Nikita")
            .Build();

        int messageId = 1;
        IMessage message = new Message(
            "Hello!",
            "How are you?",
            5);

        string topicName = "UserNikitaTopic";
        Topic topic = Topic.Builder
            .WithName(topicName)
            .WithAddressee(new AddresseeBuilder()
                .WithImportanceLevel(5)
                .WithLogger(new ConsoleLogger())
                .BuildUserAddressee(user))
            .Build();

        var messageSender = new MessageSender();
        messageSender.AddTopic(topic);

        MessageStatus result;

        // Act
        messageSender.SendMessageToTopic(topicName, message);
        user.MarkMessageAsRead(messageId);
        result = user.GetMessageStatusById(messageId);

        // Assert
        Assert.IsType<MessageStatus.Read>(result);
    }

    [Fact]
    public void ReadMessageUserTwiceTest()
    {
        // Arrange
        IUser user = User.Builder
            .WithName("Nikita")
            .Build();

        int messageId = 1;
        IMessage message = new Message(
            "Hello!",
            "How are you?",
            5);

        string topicName = "UserNikitaTopic";
        Topic topic = Topic.Builder
            .WithName(topicName)
            .WithAddressee(new AddresseeBuilder()
                .WithImportanceLevel(5)
                .WithLogger(new ConsoleLogger())
                .BuildUserAddressee(user))
            .Build();

        var messageSender = new MessageSender();
        messageSender.AddTopic(topic);

        AlreadyReadMessageException? exception = null;

        // Act
        messageSender.SendMessageToTopic(topicName, message);
        user.MarkMessageAsRead(messageId);
        try
        {
            user.MarkMessageAsRead(messageId);
        }
        catch (AlreadyReadMessageException e)
        {
            exception = e;
        }

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void AddresseeFilterTest()
    {
        // Arrange
        var userMock = new Mock<IUser>();
        int userCalls = 0;
        userMock.Setup(x => x.ReceiveMessage(It.IsAny<IMessage>()))
            .Callback(() => userCalls++);

        IMessage firstMessage = new Message(
            "Hello!",
            "How are you?",
            5);
        IMessage secondMessage = new Message(
            "Hello!",
            "ITS A TOP SECRET MESSAGE, [DATA DELETED]!",
            15);

        string topicName = "DisplayTopic";
        Topic topic = Topic.Builder
            .WithName(topicName)
            .WithAddressee(new AddresseeBuilder()
                .WithImportanceLevel(10)
                .WithLogger(new ConsoleLogger())
                .BuildUserAddressee(userMock.Object))
            .Build();

        var messageSender = new MessageSender();
        messageSender.AddTopic(topic);

        int firstMessageCount = 3;
        int secondMessageCount = 5;

        // Act
        for (int i = 0; i < firstMessageCount; i++)
        {
            messageSender.SendMessageToTopic(topicName, firstMessage);
        }

        for (int i = 0; i < secondMessageCount; i++)
        {
            messageSender.SendMessageToTopic(topicName, secondMessage);
        }

        // Assert
        Assert.Equal(secondMessageCount, userCalls);
    }

    [Fact]
    public void AddresseeLoggerTest()
    {
        // Arrange
        IMessage firstMessage = new Message(
            "Hello!",
            "How are you?",
            5);
        IMessage secondMessage = new Message(
            "Hello!",
            "ITS A TOP SECRET MESSAGE, [DATA DELETED]!",
            15);

        var loggerMock = new Mock<ILogger>();
        int loggerCalls = 0;
        loggerMock.Setup(x => x.Output(It.IsAny<string>()))
            .Callback(() => loggerCalls++);

        string topicName = "DisplayTopic";
        Topic topic = Topic.Builder
            .WithName(topicName)
            .WithAddressee(new AddresseeBuilder()
                .WithImportanceLevel(10)
                .WithLogger(loggerMock.Object)
                .BuildDisplayAddressee(Display.Builder
                    .WithDisplayDriver(new DisplayDriver())
                    .WithLogger(new ConsoleLogger())
                    .Build()))
            .Build();

        var messageSender = new MessageSender();
        messageSender.AddTopic(topic);

        int firstMessageCount = 3;
        int secondMessageCount = 5;

        // Act
        for (int i = 0; i < firstMessageCount; i++)
        {
            messageSender.SendMessageToTopic(topicName, firstMessage);
        }

        for (int i = 0; i < secondMessageCount; i++)
        {
            messageSender.SendMessageToTopic(topicName, secondMessage);
        }

        // Assert
        Assert.Equal(secondMessageCount, loggerCalls);
    }

    [Fact]
    public void MessengerReceiverTest()
    {
        // Arrange
        IMessage firstMessage = new Message(
            "Hello!",
            "How are you?",
            5);
        IMessage secondMessage = new Message(
            "Hello!",
            "ITS A TOP SECRET MESSAGE, [DATA DELETED]!",
            15);

        var messengerMock = new Mock<IMessenger>();
        int messengerCalls = 0;
        messengerMock.Setup(x => x.AddMessage(It.IsAny<string>()))
            .Callback(() => messengerCalls++);

        string topicName = "DisplayTopic";
        Topic topic = Topic.Builder
            .WithName(topicName)
            .WithAddressee(new AddresseeBuilder()
                .WithImportanceLevel(10)
                .WithLogger(new ConsoleLogger())
                .BuildMessengerAddressee(messengerMock.Object))
            .Build();

        var messageSender = new MessageSender();
        messageSender.AddTopic(topic);

        int firstMessageCount = 3;
        int secondMessageCount = 5;

        // Act
        for (int i = 0; i < firstMessageCount; i++)
        {
            messageSender.SendMessageToTopic(topicName, firstMessage);
        }

        for (int i = 0; i < secondMessageCount; i++)
        {
            messageSender.SendMessageToTopic(topicName, secondMessage);
        }

        // Assert
        Assert.Equal(secondMessageCount, messengerCalls);
    }
}