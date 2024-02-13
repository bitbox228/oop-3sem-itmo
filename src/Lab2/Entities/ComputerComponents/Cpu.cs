using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsDebuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

public class Cpu : ComputerComponentBase, IEquatable<Cpu>, ICpuDebuilder
{
    public Cpu(
        string name,
        double coreFrequency,
        int coreCount,
        CpuSocket cpuSocket,
        bool graphicsCore,
        RamFrequency ramFrequency,
        int tdp,
        int powerConsumption)
        : base(name)
    {
        cpuSocket = cpuSocket ?? throw new ArgumentNullException(nameof(cpuSocket));
        ramFrequency = ramFrequency ?? throw new ArgumentNullException(nameof(ramFrequency));

        if (coreFrequency < 0) throw new NegativeValueException(nameof(coreFrequency));
        if (coreCount < 0) throw new NegativeValueException(nameof(coreCount));
        if (tdp < 0) throw new NegativeValueException(nameof(tdp));
        if (powerConsumption < 0) throw new NegativeValueException(nameof(powerConsumption));

        CoreFrequency = coreFrequency;
        CoreCount = coreCount;
        CpuSocket = cpuSocket;
        GraphicsCore = graphicsCore;
        RamFrequency = ramFrequency;
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public double CoreFrequency { get; }
    public int CoreCount { get; }
    public CpuSocket CpuSocket { get; }
    public bool GraphicsCore { get; }
    public RamFrequency RamFrequency { get; }
    public int Tdp { get; }
    public int PowerConsumption { get; }

    public bool Equals(Cpu? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name.Equals(other.Name, StringComparison.Ordinal);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return GetType() == obj.GetType() && Equals((Cpu)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode(StringComparison.Ordinal);
    }

    public ICpuBuilder Debuild(ICpuBuilder cpuBuilder)
    {
        cpuBuilder = cpuBuilder ?? throw new ArgumentNullException(nameof(cpuBuilder));

        cpuBuilder.Reset();

        cpuBuilder.WithName(Name);
        cpuBuilder.WithCoreFrequency(CoreFrequency);
        cpuBuilder.WithCoreCount(CoreCount);
        cpuBuilder.WithCpuSocket(CpuSocket);
        cpuBuilder.WithGraphicsCore(GraphicsCore);
        cpuBuilder.WithRamFrequency(RamFrequency);
        cpuBuilder.WithTdp(Tdp);
        cpuBuilder.WithPowerConsumption(PowerConsumption);

        return cpuBuilder;
    }
}