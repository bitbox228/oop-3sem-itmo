using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;

public interface IGraphicsCardBuilder
{
    IGraphicsCardBuilder WithName(string name);

    IGraphicsCardBuilder WithVideoMemorySize(int videoMemorySize);

    IGraphicsCardBuilder WithPcieVersion(int pcieVersion);

    IGraphicsCardBuilder WithChipFrequency(int chipFrequency);

    IGraphicsCardBuilder WithPowerConsumption(int powerConsumption);

    IGraphicsCardBuilder WithLength(int length);

    IGraphicsCardBuilder WithWidth(int width);

    void Reset();

    GraphicsCard Build();
}