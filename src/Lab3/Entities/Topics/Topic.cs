using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.TopicBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;

public class Topic
{
    private readonly string _name;
    private readonly IAddressee _addressee;

    public Topic(
        string name,
        IAddressee addressee)
    {
        _name = name;
        _addressee = addressee;
    }

    public static ITopicNameSelector Builder => new TopicBuilder();

    public string Name => _name;

    public void SendMessage(IMessage message)
    {
        _addressee.PassMessage(message);
    }

    private class TopicBuilder :
        ITopicBuilder,
        ITopicNameSelector,
        ITopicAddresseeSelector
    {
        private string? _name;
        private IAddressee? _addressee;

        public TopicBuilder()
        {
            _name = null;
            _addressee = null;
        }

        public ITopicAddresseeSelector WithName(string name)
        {
            _name = name;
            return this;
        }

        public ITopicBuilder WithAddressee(IAddressee addressee)
        {
            _addressee = addressee;
            return this;
        }

        public Topic Build()
        {
            return new Topic(
                _name ?? throw new ArgumentNullException(nameof(_name)),
                _addressee ?? throw new ArgumentNullException(nameof(_addressee)));
        }
    }
}