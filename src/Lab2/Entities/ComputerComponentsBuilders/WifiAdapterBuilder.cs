using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponentsBuilders;

public class WifiAdapterBuilder : IWifiAdapterBuilder
{
    private string? _name;
    private WifiStandardVersion? _wifiStandardVersion;
    private bool _bluetoothModule;
    private int _pcieVersion;
    private int _powerConsumption;

    public WifiAdapterBuilder() { }

    public IWifiAdapterBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IWifiAdapterBuilder WithWifiStandardVersion(WifiStandardVersion wifiStandardVersion)
    {
        _wifiStandardVersion = wifiStandardVersion;
        return this;
    }

    public IWifiAdapterBuilder WithBluetoothModule(bool bluetoothModule)
    {
        _bluetoothModule = bluetoothModule;
        return this;
    }

    public IWifiAdapterBuilder WithPcieVersion(int pcieVersion)
    {
        _pcieVersion = pcieVersion;
        return this;
    }

    public IWifiAdapterBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public void Reset()
    {
        _name = null;
        _wifiStandardVersion = null;
        _bluetoothModule = false;
        _pcieVersion = 0;
        _powerConsumption = 0;
    }

    public WifiAdapter Build()
    {
        return new WifiAdapter(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _wifiStandardVersion ?? throw new ArgumentNullException(nameof(_wifiStandardVersion)),
            _bluetoothModule,
            _pcieVersion,
            _powerConsumption);
    }
}