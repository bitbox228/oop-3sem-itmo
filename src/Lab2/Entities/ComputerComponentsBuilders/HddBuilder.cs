using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponentsBuilders;

public class HddBuilder : IHddBuilder
{
    private string? _name;
    private int _memorySize;
    private int _spindleSpeed;
    private int _powerConsumption;

    public HddBuilder() { }

    public IHddBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IHddBuilder WithMemorySize(int memorySize)
    {
        _memorySize = memorySize;
        return this;
    }

    public IHddBuilder WithSpindleSpeed(int spindleSpeed)
    {
        _spindleSpeed = spindleSpeed;
        return this;
    }

    public IHddBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public void Reset()
    {
        _name = null;
        _memorySize = 0;
        _spindleSpeed = 0;
        _powerConsumption = 0;
    }

    public Hdd Build()
    {
        return new Hdd(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _memorySize,
            _spindleSpeed,
            _powerConsumption);
    }
}