using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponentsBuilders;

public class MotherboardBuilder : IMotherboardBuilder
{
    private string? _name;
    private CpuSocket? _cpuSocket;
    private List<Pcie> _pciePorts;
    private int _sataPortsCount;
    private MotherboardChipset? _motherboardChipset;
    private DdrStandard? _ddrStandard;
    private int _ramSlotsCount;
    private MotherboardFormFactor? _motherboardFormFactor;
    private Bios? _bios;
    private bool _wifiModule;

    public MotherboardBuilder()
    {
        _pciePorts = new List<Pcie>();
    }

    public IMotherboardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IMotherboardBuilder WithCpuSocket(CpuSocket cpuSocket)
    {
        _cpuSocket = cpuSocket;
        return this;
    }

    public IMotherboardBuilder AddPciePort(Pcie pcie)
    {
        _pciePorts.Add(pcie);
        return this;
    }

    public IMotherboardBuilder WithSataPorts(int sataPortsCount)
    {
        _sataPortsCount = sataPortsCount;
        return this;
    }

    public IMotherboardBuilder WithMotherboardChipset(MotherboardChipset motherboardChipset)
    {
        _motherboardChipset = motherboardChipset;
        return this;
    }

    public IMotherboardBuilder WithDdrStandard(DdrStandard ddrStandard)
    {
        _ddrStandard = ddrStandard;
        return this;
    }

    public IMotherboardBuilder WithRamSlots(int ramSlotsCount)
    {
        _ramSlotsCount = ramSlotsCount;
        return this;
    }

    public IMotherboardBuilder WithMotherboardFormFactor(MotherboardFormFactor motherboardFormFactor)
    {
        _motherboardFormFactor = motherboardFormFactor;
        return this;
    }

    public IMotherboardBuilder WithBios(Bios bios)
    {
        _bios = bios;
        return this;
    }

    public IMotherboardBuilder WithWifiModule(bool wifiModule)
    {
        _wifiModule = wifiModule;
        return this;
    }

    public void Reset()
    {
        _name = null;
        _cpuSocket = null;
        _pciePorts.Clear();
        _sataPortsCount = 0;
        _motherboardChipset = null;
        _ddrStandard = null;
        _ramSlotsCount = 0;
        _motherboardFormFactor = null;
        _bios = null;
    }

    public Motherboard Build()
    {
        return new Motherboard(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _cpuSocket ?? throw new ArgumentNullException(nameof(_cpuSocket)),
            _pciePorts,
            _sataPortsCount,
            _motherboardChipset ?? throw new ArgumentNullException(nameof(_motherboardChipset)),
            _ddrStandard ?? throw new ArgumentNullException(nameof(_ddrStandard)),
            _ramSlotsCount,
            _motherboardFormFactor ?? throw new ArgumentNullException(nameof(_motherboardFormFactor)),
            _bios ?? throw new ArgumentNullException(nameof(_bios)),
            _wifiModule);
    }
}