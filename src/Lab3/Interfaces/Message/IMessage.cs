namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Message;

public interface IMessage
{
    int ImportanceLevel { get; }

    string Render();
}