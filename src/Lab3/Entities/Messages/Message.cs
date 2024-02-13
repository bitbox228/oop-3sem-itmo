using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class Message : IMessage
{
    private readonly string _name;
    private readonly string _body;

    public Message(
        string name,
        string body,
        int importanceLevel)
    {
        if (importanceLevel < 0) throw new NegativeValueException(nameof(importanceLevel));

        _name = name;
        _body = body;
        ImportanceLevel = importanceLevel;
    }

    public int ImportanceLevel { get; }

    public string Render()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append(_name);
        stringBuilder.Append("\n\n");
        stringBuilder.Append(_body);

        return stringBuilder.ToString();
    }
}