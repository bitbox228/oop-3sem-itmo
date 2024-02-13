using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

public class Psu : ComputerComponentBase, IEquatable<Psu>
{
    public Psu(string name, int peakLoad)
        : base(name)
    {
        if (peakLoad < 0) throw new NegativeValueException(nameof(peakLoad));

        PeakLoad = peakLoad;
    }

    public int PeakLoad { get; }

    public bool Equals(Psu? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name.Equals(other.Name, StringComparison.Ordinal);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return GetType() == obj.GetType() && Equals((Psu)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode(StringComparison.Ordinal);
    }
}