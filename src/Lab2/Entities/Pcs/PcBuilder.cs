using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerValidator;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.PcBuilder;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;

public class PcBuilder : IPcBuilder
{
    private Motherboard? _motherboard;
    private Cpu? _cpu;
    private Heatsink? _heatsink;
    private List<Ram> _ramSticks;
    private GraphicsCard? _graphicsCard;
    private List<Ssd> _ssdDisks;
    private List<Hdd> _hddDisks;
    private ComputerCase? _computerCase;
    private Psu? _psu;
    private WifiAdapter? _wifiAdapter;
    private IComputerValidator? _computerValidator;

    public PcBuilder(IComputerValidator? computerValidator)
    {
        _computerValidator = computerValidator;
        _ramSticks = new List<Ram>();
        _ssdDisks = new List<Ssd>();
        _hddDisks = new List<Hdd>();
    }

    public IPcBuilder WithMotherBoard(Motherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public IPcBuilder WithCpu(Cpu cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IPcBuilder WithHeatsink(Heatsink heatsink)
    {
        _heatsink = heatsink;
        return this;
    }

    public IPcBuilder AddRam(Ram ram)
    {
        _ramSticks.Add(ram);
        return this;
    }

    public IPcBuilder WithGraphicsCard(GraphicsCard graphicsCard)
    {
        _graphicsCard = graphicsCard;
        return this;
    }

    public IPcBuilder AddSsd(Ssd ssd)
    {
        _ssdDisks.Add(ssd);
        return this;
    }

    public IPcBuilder AddHdd(Hdd hdd)
    {
        _hddDisks.Add(hdd);
        return this;
    }

    public IPcBuilder WithComputerCase(ComputerCase computerCase)
    {
        _computerCase = computerCase;
        return this;
    }

    public IPcBuilder WithPsu(Psu psu)
    {
        _psu = psu;
        return this;
    }

    public IPcBuilder WithWifiAdapter(WifiAdapter wifiAdapter)
    {
        _wifiAdapter = wifiAdapter;
        return this;
    }

    public void Reset()
    {
        _motherboard = null;
        _cpu = null;
        _heatsink = null;
        _ramSticks.Clear();
        _graphicsCard = null;
        _ssdDisks.Clear();
        _hddDisks.Clear();
        _computerCase = null;
        _psu = null;
        _wifiAdapter = null;
    }

    public PcBuildResult Build()
    {
        var mandatoryComponentsValidator = new MandatoryComponentsValidator();

        ComponentsValidationResult mandatoryComponentsValidationResult = mandatoryComponentsValidator.Validate(
            _motherboard,
            _cpu,
            _heatsink,
            _computerCase,
            _psu);

        if (mandatoryComponentsValidationResult is ComponentsValidationResult.NoMandatoryComponent result)
        {
            string comment = result.Comment;
            return new PcBuildResult.NoMandatoryComponent(comment);
        }

        var pc = new Pc(
            _motherboard ?? throw new ArgumentNullException(nameof(_motherboard)),
            _cpu ?? throw new ArgumentNullException(nameof(_cpu)),
            _heatsink ?? throw new ArgumentNullException(nameof(_heatsink)),
            _ramSticks,
            _graphicsCard,
            _ssdDisks,
            _hddDisks,
            _computerCase ?? throw new ArgumentNullException(nameof(_computerCase)),
            _psu ?? throw new ArgumentNullException(nameof(_psu)),
            _wifiAdapter);

        if (_computerValidator is null) return new PcBuildResult.Success(pc);

        ComponentsValidationResult validationResult = _computerValidator.Validate(pc);

        return validationResult switch
        {
            ComponentsValidationResult.IncompatibleComputerComponents failedValidationResult =>
                new PcBuildResult.IncompatibleComputerComponents(failedValidationResult.Comment),

            ComponentsValidationResult.WarrantyDisclaimer => new PcBuildResult.WarrantyDisclaimer(pc),

            ComponentsValidationResult.PowerConsumptionWarning => new PcBuildResult.PowerConsumptionWarning(pc),

            ComponentsValidationResult.NoMandatoryComponent failedValidationResult =>
                new PcBuildResult.NoMandatoryComponent(failedValidationResult.Comment),

            _ => new PcBuildResult.Success(pc),
        };
    }
}