using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;

public interface ISsdBuilder
{
    ISsdBuilder WithName(string name);

    ISsdBuilder WithConnectionType(ConnectionType connectionType);

    ISsdBuilder WithMemorySize(int memorySize);

    ISsdBuilder WithMaxOperatingSpeed(int maxOperatingSpeed);

    ISsdBuilder WithPowerConsumption(int powerConsumption);

    void Reset();

    Ssd Build();
}