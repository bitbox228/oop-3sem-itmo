using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponentsBuilders;

public class RamBuilder : IRamBuilder
{
    private string? _name;
    private int _memorySize;
    private List<Jedec> _supportedJedecs;
    private List<int> _supportedVoltage;
    private List<XmpProfile> _supportedXmpProfiles;
    private RamFormFactor? _ramFormFactor;
    private DdrStandard? _ddrStandard;
    private int _powerConsumption;

    public RamBuilder()
    {
        _supportedJedecs = new List<Jedec>();
        _supportedVoltage = new List<int>();
        _supportedXmpProfiles = new List<XmpProfile>();
    }

    public IRamBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IRamBuilder WithMemorySize(int memorySize)
    {
        _memorySize = memorySize;
        return this;
    }

    public IRamBuilder AddSupportedJedec(Jedec jedec)
    {
        _supportedJedecs.Add(jedec);
        return this;
    }

    public IRamBuilder AddSupportedVoltage(int voltage)
    {
        _supportedVoltage.Add(voltage);
        return this;
    }

    public IRamBuilder AddXmpProfile(XmpProfile xmpProfile)
    {
        _supportedXmpProfiles.Add(xmpProfile);
        return this;
    }

    public IRamBuilder WithRamFormFactor(RamFormFactor ramFormFactor)
    {
        _ramFormFactor = ramFormFactor;
        return this;
    }

    public IRamBuilder WithDdrStandart(DdrStandard ddrStandard)
    {
        _ddrStandard = ddrStandard;
        return this;
    }

    public IRamBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public void Reset()
    {
        _name = null;
        _memorySize = 0;
        _supportedJedecs.Clear();
        _supportedVoltage.Clear();
        _supportedXmpProfiles.Clear();
        _ramFormFactor = null;
        _ddrStandard = null;
        _powerConsumption = 0;
    }

    public Ram Build()
    {
        return new Ram(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _memorySize,
            _supportedJedecs,
            _supportedVoltage,
            _supportedXmpProfiles,
            _ramFormFactor ?? throw new ArgumentNullException(nameof(_ramFormFactor)),
            _ddrStandard ?? throw new ArgumentNullException(nameof(_ddrStandard)),
            _powerConsumption);
    }
}