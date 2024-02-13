using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerAttributesCollections;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

public class DdrStandard : IEquatable<DdrStandard>
{
    public DdrStandard(string name)
    {
        var ddrStandardsList = new DdrStandardsList();
        if (!ddrStandardsList.Contains(name))
            throw new InvalidAttributeNameException(nameof(DdrStandard), name);

        Name = name;
    }

    public string Name { get; }

    public bool Equals(DdrStandard? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name.Equals(other.Name, StringComparison.Ordinal);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return GetType() == obj.GetType() && Equals((DdrStandard)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode(StringComparison.Ordinal);
    }
}