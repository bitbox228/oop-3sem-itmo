using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponentsBuilders;

public class SsdBuilder : ISsdBuilder
{
    private string? _name;
    private ConnectionType? _connectionType;
    private int _memorySize;
    private int _maxOperatingSpeed;
    private int _powerConsumption;

    public SsdBuilder() { }

    public ISsdBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ISsdBuilder WithConnectionType(ConnectionType connectionType)
    {
        _connectionType = connectionType;
        return this;
    }

    public ISsdBuilder WithMemorySize(int memorySize)
    {
        _memorySize = memorySize;
        return this;
    }

    public ISsdBuilder WithMaxOperatingSpeed(int maxOperatingSpeed)
    {
        _maxOperatingSpeed = maxOperatingSpeed;
        return this;
    }

    public ISsdBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public void Reset()
    {
        _name = null;
        _connectionType = null;
        _memorySize = 0;
        _maxOperatingSpeed = 0;
        _powerConsumption = 0;
    }

    public Ssd Build()
    {
        return new Ssd(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _connectionType ?? throw new ArgumentNullException(nameof(_connectionType)),
            _memorySize,
            _maxOperatingSpeed,
            _powerConsumption);
    }
}