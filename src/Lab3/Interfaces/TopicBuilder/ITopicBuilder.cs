using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Addressee;

namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces.TopicBuilder;

public interface ITopicBuilder
{
    Topic Build();
}

public interface ITopicNameSelector
{
    ITopicAddresseeSelector WithName(string name);
}

public interface ITopicAddresseeSelector
{
    ITopicBuilder WithAddressee(IAddressee addressee);
}