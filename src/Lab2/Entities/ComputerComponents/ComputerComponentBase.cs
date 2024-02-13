namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

public abstract class ComputerComponentBase
{
    protected ComputerComponentBase(string name)
    {
        Name = name;
    }

    public string Name { get; }
}