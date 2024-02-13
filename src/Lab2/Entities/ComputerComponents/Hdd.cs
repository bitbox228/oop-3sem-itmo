using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsDebuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

public class Hdd : ComputerComponentBase, IEquatable<Hdd>, IHddDebuilder
{
    public Hdd(
        string name,
        int memorySize,
        int spindleSpeed,
        int powerConsumption)
        : base(name)
    {
        if (memorySize < 0) throw new NegativeValueException(nameof(memorySize));
        if (spindleSpeed < 0) throw new NegativeValueException(nameof(spindleSpeed));
        if (powerConsumption < 0) throw new NegativeValueException(nameof(powerConsumption));

        MemorySize = memorySize;
        SpindleSpeed = spindleSpeed;
        PowerConsumption = powerConsumption;
    }

    public int MemorySize { get; }
    public int SpindleSpeed { get; }
    public int PowerConsumption { get; }

    public bool Equals(Hdd? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name.Equals(other.Name, StringComparison.Ordinal);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return GetType() == obj.GetType() && Equals((Hdd)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode(StringComparison.Ordinal);
    }

    public IHddBuilder Debuild(IHddBuilder hddBuilder)
    {
        hddBuilder = hddBuilder ?? throw new ArgumentNullException(nameof(hddBuilder));

        hddBuilder.Reset();

        hddBuilder.WithName(Name);
        hddBuilder.WithMemorySize(MemorySize);
        hddBuilder.WithSpindleSpeed(SpindleSpeed);
        hddBuilder.WithPowerConsumption(PowerConsumption);

        return hddBuilder;
    }
}