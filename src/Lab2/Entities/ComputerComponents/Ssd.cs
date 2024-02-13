using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsDebuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

public class Ssd : ComputerComponentBase, IEquatable<Ssd>, ISsdDebuilder
{
    public Ssd(
        string name,
        ConnectionType connectionType,
        int memorySize,
        int maxOperatingSpeed,
        int powerConsumption)
        : base(name)
    {
        connectionType = connectionType ?? throw new ArgumentNullException(nameof(connectionType));

        if (memorySize < 0) throw new NegativeValueException(nameof(memorySize));
        if (maxOperatingSpeed < 0) throw new NegativeValueException(nameof(maxOperatingSpeed));
        if (powerConsumption < 0) throw new NegativeValueException(nameof(powerConsumption));

        ConnectionType = connectionType;
        MemorySize = memorySize;
        MaxOperatingSpeed = maxOperatingSpeed;
        PowerConsumption = powerConsumption;
    }

    public ConnectionType ConnectionType { get; }
    public int MemorySize { get; }
    public int MaxOperatingSpeed { get; }
    public int PowerConsumption { get; }

    public bool Equals(Ssd? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name.Equals(other.Name, StringComparison.Ordinal);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return GetType() == obj.GetType() && Equals((Ssd)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode(StringComparison.Ordinal);
    }

    public ISsdBuilder Debuild(ISsdBuilder ssdBuilder)
    {
        ssdBuilder = ssdBuilder ?? throw new ArgumentNullException(nameof(ssdBuilder));

        ssdBuilder.Reset();

        ssdBuilder.WithName(Name);
        ssdBuilder.WithConnectionType(ConnectionType);
        ssdBuilder.WithMemorySize(MemorySize);
        ssdBuilder.WithMaxOperatingSpeed(MaxOperatingSpeed);
        ssdBuilder.WithPowerConsumption(PowerConsumption);

        return ssdBuilder;
    }
}