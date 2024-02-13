using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsDebuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

public class Motherboard : ComputerComponentBase, IEquatable<Motherboard>, IMotherboardDebuilder
{
    public Motherboard(
        string name,
        CpuSocket cpuSocket,
        IEnumerable<Pcie> pciePorts,
        int sataPortsCount,
        MotherboardChipset motherboardChipset,
        DdrStandard ddrStandard,
        int ramSlotsCount,
        MotherboardFormFactor motherboardFormFactor,
        Bios bios,
        bool wifiModule)
        : base(name)
    {
        cpuSocket = cpuSocket ?? throw new ArgumentNullException(nameof(cpuSocket));
        motherboardChipset = motherboardChipset ?? throw new ArgumentNullException(nameof(motherboardChipset));
        ddrStandard = ddrStandard ?? throw new ArgumentNullException(nameof(ddrStandard));
        motherboardFormFactor = motherboardFormFactor ?? throw new ArgumentNullException(nameof(motherboardFormFactor));

        if (sataPortsCount < 0) throw new NegativeValueException(nameof(sataPortsCount));
        if (ramSlotsCount < 0) throw new NegativeValueException(nameof(ramSlotsCount));

        CpuSocket = cpuSocket;
        PciePorts = pciePorts.ToArray();
        SataPortsCount = sataPortsCount;
        MotherboardChipset = motherboardChipset;
        DdrStandard = ddrStandard;
        RamSlotsCount = ramSlotsCount;
        MotherboardFormFactor = motherboardFormFactor;
        Bios = bios;
        WifiModule = wifiModule;

        if (PciePorts.Any(pciePort => pciePort is null))
        {
            throw new ArgumentNullException(nameof(pciePorts));
        }
    }

    public CpuSocket CpuSocket { get; }
    public IReadOnlyCollection<Pcie> PciePorts { get; }
    public int SataPortsCount { get; }
    public MotherboardChipset MotherboardChipset { get; }
    public DdrStandard DdrStandard { get; }
    public int RamSlotsCount { get; }
    public MotherboardFormFactor MotherboardFormFactor { get; }
    public Bios Bios { get; }
    public bool WifiModule { get; }

    public bool Equals(Motherboard? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name.Equals(other.Name, StringComparison.Ordinal);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return GetType() == obj.GetType() && Equals((Motherboard)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode(StringComparison.Ordinal);
    }

    public IMotherboardBuilder Debuild(IMotherboardBuilder motherboardBuilder)
    {
        motherboardBuilder = motherboardBuilder ?? throw new ArgumentNullException(nameof(motherboardBuilder));

        motherboardBuilder.Reset();

        motherboardBuilder.WithName(Name);
        motherboardBuilder.WithCpuSocket(CpuSocket);

        IEnumerable<IMotherboardBuilder> motherboardBuilders = PciePorts
            .Select(pcie => motherboardBuilder.AddPciePort(pcie));

        motherboardBuilder.WithSataPorts(SataPortsCount);
        motherboardBuilder.WithMotherboardChipset(MotherboardChipset);
        motherboardBuilder.WithDdrStandard(DdrStandard);
        motherboardBuilder.WithRamSlots(RamSlotsCount);
        motherboardBuilder.WithMotherboardFormFactor(MotherboardFormFactor);
        motherboardBuilder.WithBios(Bios);

        return motherboardBuilder;
    }
}