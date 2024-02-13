using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponentsBuilders;

public class CpuBuilder : ICpuBuilder
{
    private string? _name;
    private double _coreFrequency;
    private int _coreCount;
    private CpuSocket? _cpuSocket;
    private bool _graphicCore;
    private RamFrequency? _ramFrequency;
    private int _tdp;
    private int _powerConsumption;

    public CpuBuilder() { }

    public ICpuBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ICpuBuilder WithCoreFrequency(double coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public ICpuBuilder WithCoreCount(int coreCount)
    {
        _coreCount = coreCount;
        return this;
    }

    public ICpuBuilder WithCpuSocket(CpuSocket cpuSocket)
    {
        _cpuSocket = cpuSocket;
        return this;
    }

    public ICpuBuilder WithGraphicsCore(bool graphicsCore)
    {
        _graphicCore = graphicsCore;
        return this;
    }

    public ICpuBuilder WithRamFrequency(RamFrequency ramFrequency)
    {
        _ramFrequency = ramFrequency;
        return this;
    }

    public ICpuBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ICpuBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public void Reset()
    {
        _name = null;
        _coreFrequency = 0;
        _coreCount = 0;
        _cpuSocket = null;
        _graphicCore = false;
        _ramFrequency = null;
        _tdp = 0;
        _powerConsumption = 0;
    }

    public Cpu Build()
    {
        return new Cpu(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _coreFrequency,
            _coreCount,
            _cpuSocket ?? throw new ArgumentNullException(nameof(_cpuSocket)),
            _graphicCore,
            _ramFrequency ?? throw new ArgumentNullException(nameof(_ramFrequency)),
            _tdp,
            _powerConsumption);
    }
}