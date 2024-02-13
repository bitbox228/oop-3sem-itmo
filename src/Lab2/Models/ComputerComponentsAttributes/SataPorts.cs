using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

public class SataPorts : IEquatable<SataPorts>
{
    public SataPorts(int count)
    {
        if (count < 0) throw new NegativeValueException(nameof(count));

        Count = count;
    }

    public int Count { get; }

    public bool Equals(SataPorts? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Count == other.Count;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return GetType() == obj.GetType() && Equals((SataPorts)obj);
    }

    public override int GetHashCode()
    {
        return Count.GetHashCode();
    }
}