using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

public class XmpProfile : IEquatable<XmpProfile>
{
    public XmpProfile(
        RamTimings ramTimings,
        int voltage,
        int frequency)
    {
        ramTimings = ramTimings ?? throw new ArgumentNullException(nameof(ramTimings));

        if (voltage < 0) throw new NegativeValueException(nameof(voltage));
        if (frequency < 0) throw new NegativeValueException(nameof(frequency));

        RamTimings = ramTimings;
        Voltage = voltage;
        Frequency = frequency;
    }

    public RamTimings RamTimings { get; }
    public int Voltage { get; }
    public int Frequency { get; }

    public bool Equals(XmpProfile? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return RamTimings.Equals(other.RamTimings) &&
               Voltage.Equals(other.Voltage) &&
               Frequency.Equals(other.Frequency);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return GetType() == obj.GetType() && Equals((XmpProfile)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(RamTimings, Voltage, Frequency);
    }
}