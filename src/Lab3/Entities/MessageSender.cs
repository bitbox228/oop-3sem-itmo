using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class MessageSender
{
    private readonly Dictionary<string, Topic> _topics;

    public MessageSender()
    {
        _topics = new Dictionary<string, Topic>();
    }

    public void AddTopic(Topic topic)
    {
        topic = topic ?? throw new ArgumentNullException(nameof(topic));

        _topics.TryAdd(topic.Name, topic);
    }

    public void SendMessageToTopic(string topicName, IMessage message)
    {
        KeyValuePair<string, Topic> topic =
            _topics.FirstOrDefault(x => x.Key.Equals(topicName, StringComparison.Ordinal));

        if (topic.Equals(default(KeyValuePair<string, Topic>)))
        {
            throw new InvalidTopicNameException(topicName);
        }

        topic.Value.SendMessage(message);
    }
}