using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsDebuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

public class Heatsink : ComputerComponentBase, IEquatable<Heatsink>, IHeatsinkDebuilder
{
    public Heatsink(
        string name,
        Dimensions dimensions,
        IEnumerable<CpuSocket> supportedSockets,
        int tdp)
        : base(name)
    {
        if (tdp < 0) throw new NegativeValueException(nameof(tdp));

        Dimensions = dimensions;
        SupportedSockets = supportedSockets.ToArray();
        Tdp = tdp;

        if (SupportedSockets.Any(supportedSocket => supportedSocket is null))
        {
            throw new ArgumentNullException(nameof(supportedSockets));
        }
    }

    public Dimensions Dimensions { get; }
    public IReadOnlyCollection<CpuSocket> SupportedSockets { get; }
    public int Tdp { get; }

    public bool Equals(Heatsink? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name.Equals(other.Name, StringComparison.Ordinal);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return GetType() == obj.GetType() && Equals((Heatsink)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode(StringComparison.Ordinal);
    }

    public IHeatsinkBuilder Debuild(IHeatsinkBuilder heatsinkBuilder)
    {
        heatsinkBuilder = heatsinkBuilder ?? throw new ArgumentNullException(nameof(heatsinkBuilder));

        heatsinkBuilder.Reset();

        heatsinkBuilder.WithName(Name);
        heatsinkBuilder.WithDimensions(Dimensions);

        IEnumerable<IHeatsinkBuilder> heatsinkBuilders = SupportedSockets
            .Select(cpuSocket => heatsinkBuilder.AddSupportedSocket(cpuSocket));

        heatsinkBuilder.WithTdp(Tdp);

        return heatsinkBuilder;
    }
}