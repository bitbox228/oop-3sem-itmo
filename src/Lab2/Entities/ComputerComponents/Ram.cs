using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsDebuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

public class Ram : ComputerComponentBase, IEquatable<Ram>, IRamDebuilder
{
    public Ram(
        string name,
        int memorySize,
        IEnumerable<Jedec> supportedJedecs,
        IEnumerable<int> supportedVoltage,
        IEnumerable<XmpProfile> supportedXmpProfiles,
        RamFormFactor ramFormFactor,
        DdrStandard ddrStandard,
        int powerConsumption)
        : base(name)
    {
        ramFormFactor = ramFormFactor ?? throw new ArgumentNullException(nameof(ramFormFactor));
        ddrStandard = ddrStandard ?? throw new ArgumentNullException(nameof(ddrStandard));

        if (memorySize < 0) throw new NegativeValueException(nameof(memorySize));
        if (powerConsumption < 0) throw new NegativeValueException(nameof(powerConsumption));

        MemorySize = memorySize;
        SupportedJedecs = supportedJedecs.ToArray();
        SupportedVoltage = supportedVoltage.ToArray();
        SupportedXmpProfiles = supportedXmpProfiles.ToArray();
        RamFormFactor = ramFormFactor;
        DdrStandard = ddrStandard;
        PowerConsumption = powerConsumption;

        if (SupportedJedecs.Any(supportedJedec => supportedJedec is null))
        {
            throw new ArgumentNullException(nameof(supportedJedecs));
        }

        if (SupportedVoltage.Any(voltage => voltage < 0))
        {
            throw new NegativeValueException(nameof(SupportedVoltage));
        }

        if (SupportedXmpProfiles.Any(supportedXmp => supportedXmp is null))
        {
            throw new ArgumentNullException(nameof(supportedXmpProfiles));
        }
    }

    public int MemorySize { get; }
    public IReadOnlyCollection<Jedec> SupportedJedecs { get; }
    public IReadOnlyCollection<int> SupportedVoltage { get; }
    public IReadOnlyCollection<XmpProfile> SupportedXmpProfiles { get; }
    public RamFormFactor RamFormFactor { get; }
    public DdrStandard DdrStandard { get; }
    public int PowerConsumption { get; }

    public bool Equals(Ram? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name.Equals(other.Name, StringComparison.Ordinal);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return GetType() == obj.GetType() && Equals((Ram)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode(StringComparison.Ordinal);
    }

    public IRamBuilder Debuild(IRamBuilder ramBuilder)
    {
        ramBuilder = ramBuilder ?? throw new ArgumentNullException(nameof(ramBuilder));

        ramBuilder.Reset();

        ramBuilder.WithName(Name);
        ramBuilder.WithMemorySize(MemorySize);

        IEnumerable<IRamBuilder> ramBuildersJedec = SupportedJedecs.Select(jedec
            => ramBuilder.AddSupportedJedec(jedec));

        IEnumerable<IRamBuilder> ramBuildersVoltage = SupportedVoltage.Select(voltage
            => ramBuilder.AddSupportedVoltage(voltage));

        IEnumerable<IRamBuilder> ramBuildersXmp = SupportedXmpProfiles.Select(xmpProfile
            => ramBuilder.AddXmpProfile(xmpProfile));

        ramBuilder.WithRamFormFactor(RamFormFactor);
        ramBuilder.WithDdrStandart(DdrStandard);
        ramBuilder.WithPowerConsumption(PowerConsumption);

        return ramBuilder;
    }
}