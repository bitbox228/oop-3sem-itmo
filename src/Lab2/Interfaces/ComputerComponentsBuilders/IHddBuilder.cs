using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;

public interface IHddBuilder
{
    IHddBuilder WithName(string name);

    IHddBuilder WithMemorySize(int memorySize);

    IHddBuilder WithSpindleSpeed(int spindleSpeed);

    IHddBuilder WithPowerConsumption(int powerConsumption);

    void Reset();

    Hdd Build();
}