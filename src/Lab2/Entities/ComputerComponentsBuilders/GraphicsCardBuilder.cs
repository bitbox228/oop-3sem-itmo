using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponentsBuilders;

public class GraphicsCardBuilder : IGraphicsCardBuilder
{
    private string? _name;
    private int _videoMemorySize;
    private int _pcieVersion;
    private int _chipFrequency;
    private int _powerConsumption;
    private int _length;
    private int _width;

    public GraphicsCardBuilder() { }

    public IGraphicsCardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IGraphicsCardBuilder WithVideoMemorySize(int videoMemorySize)
    {
        _videoMemorySize = videoMemorySize;
        return this;
    }

    public IGraphicsCardBuilder WithPcieVersion(int pcieVersion)
    {
        _pcieVersion = pcieVersion;
        return this;
    }

    public IGraphicsCardBuilder WithChipFrequency(int chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public IGraphicsCardBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IGraphicsCardBuilder WithLength(int length)
    {
        _length = length;
        return this;
    }

    public IGraphicsCardBuilder WithWidth(int width)
    {
        _width = width;
        return this;
    }

    public void Reset()
    {
        _name = null;
        _videoMemorySize = 0;
        _pcieVersion = 0;
        _chipFrequency = 0;
        _powerConsumption = 0;
        _length = 0;
        _width = 0;
    }

    public GraphicsCard Build()
    {
        return new GraphicsCard(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _videoMemorySize,
            _pcieVersion,
            _chipFrequency,
            _powerConsumption,
            _length,
            _width);
    }
}