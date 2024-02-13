using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponentsBuilders;

public class HeatsinkBuilder : IHeatsinkBuilder
{
    private string? _name;
    private Dimensions? _dimensions;
    private List<CpuSocket> _supportedCpuSockets;
    private int _tdp;

    public HeatsinkBuilder()
    {
        _supportedCpuSockets = new List<CpuSocket>();
    }

    public IHeatsinkBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IHeatsinkBuilder WithDimensions(Dimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public IHeatsinkBuilder AddSupportedSocket(CpuSocket cpuSocket)
    {
        _supportedCpuSockets.Add(cpuSocket);
        return this;
    }

    public IHeatsinkBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public void Reset()
    {
        _name = null;
        _dimensions = null;
        _supportedCpuSockets.Clear();
        _tdp = 0;
    }

    public Heatsink Build()
    {
        return new Heatsink(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)),
            _supportedCpuSockets,
            _tdp);
    }
}