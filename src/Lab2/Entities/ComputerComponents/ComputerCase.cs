using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsDebuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

public class ComputerCase : ComputerComponentBase, IEquatable<ComputerCase>, IComputerCaseDebuilder
{
    public ComputerCase(
        string name,
        int maxGraphicsCardLength,
        int maxGraphicsCardWidth,
        IEnumerable<MotherboardFormFactor> supportedMotherboardFormFactors,
        Dimensions dimensions)
        : base(name)
    {
        dimensions = dimensions ?? throw new ArgumentNullException(nameof(dimensions));

        if (maxGraphicsCardLength < 0) throw new NegativeValueException(nameof(maxGraphicsCardLength));
        if (maxGraphicsCardWidth < 0) throw new NegativeValueException(nameof(maxGraphicsCardWidth));

        MaxGraphicsCardLength = maxGraphicsCardLength;
        MaxGraphicsCardWidth = maxGraphicsCardWidth;
        Dimensions = dimensions;
        SupportedMotherboardFormFactors = supportedMotherboardFormFactors.ToArray();

        if (SupportedMotherboardFormFactors.Any(
                supportedMotherboardFormFactor => supportedMotherboardFormFactor is null))
        {
            throw new ArgumentNullException(nameof(supportedMotherboardFormFactors));
        }
    }

    public int MaxGraphicsCardLength { get; }
    public int MaxGraphicsCardWidth { get; }
    public IReadOnlyCollection<MotherboardFormFactor> SupportedMotherboardFormFactors { get; }
    public Dimensions Dimensions { get; }

    public bool Equals(ComputerCase? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name.Equals(other.Name, StringComparison.Ordinal);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return GetType() == obj.GetType() && Equals((ComputerCase)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode(StringComparison.Ordinal);
    }

    public IComputerCaseBuilder Debuild(IComputerCaseBuilder computerCaseBuilder)
    {
        computerCaseBuilder = computerCaseBuilder ?? throw new ArgumentNullException(nameof(computerCaseBuilder));

        computerCaseBuilder.Reset();

        computerCaseBuilder.WithName(Name);
        computerCaseBuilder.WithMaxGraphicsCardLength(MaxGraphicsCardLength);
        computerCaseBuilder.WithMaxGraphicsCardWidth(MaxGraphicsCardWidth);

        IEnumerable<IComputerCaseBuilder> computerCaseBuilders = SupportedMotherboardFormFactors
            .Select(motherboardFormFactor =>
                computerCaseBuilder.AddSupportedMotherboardFormFactor(motherboardFormFactor));

        computerCaseBuilder.WithDimensions(Dimensions);

        return computerCaseBuilder;
    }
}