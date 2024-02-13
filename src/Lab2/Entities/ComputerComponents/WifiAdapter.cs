using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsDebuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

public class WifiAdapter : ComputerComponentBase, IEquatable<WifiAdapter>, IWifiAdapterDebuilder
{
    public WifiAdapter(
        string name,
        WifiStandardVersion wifiStandardVersion,
        bool bluetoothModule,
        int pcieVersion,
        int powerConsumption)
        : base(name)
    {
        wifiStandardVersion = wifiStandardVersion ?? throw new ArgumentNullException(nameof(wifiStandardVersion));

        if (pcieVersion < 0) throw new NegativeValueException(nameof(pcieVersion));
        if (powerConsumption < 0) throw new NegativeValueException(nameof(powerConsumption));

        WifiStandardVersion = wifiStandardVersion;
        BluetoothModule = bluetoothModule;
        PcieVersion = pcieVersion;
        PowerConsumption = powerConsumption;
    }

    public WifiStandardVersion WifiStandardVersion { get; }
    public bool BluetoothModule { get; }
    public int PcieVersion { get; }
    public int PowerConsumption { get; }

    public bool Equals(WifiAdapter? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name.Equals(other.Name, StringComparison.Ordinal);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return GetType() == obj.GetType() && Equals((WifiAdapter)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode(StringComparison.Ordinal);
    }

    public IWifiAdapterBuilder Debuild(IWifiAdapterBuilder wifiAdapterBuilder)
    {
        wifiAdapterBuilder = wifiAdapterBuilder ?? throw new ArgumentNullException(nameof(wifiAdapterBuilder));

        wifiAdapterBuilder.Reset();

        wifiAdapterBuilder.WithName(Name);
        wifiAdapterBuilder.WithWifiStandardVersion(WifiStandardVersion);
        wifiAdapterBuilder.WithBluetoothModule(BluetoothModule);
        wifiAdapterBuilder.WithPcieVersion(PcieVersion);
        wifiAdapterBuilder.WithPowerConsumption(PowerConsumption);

        return wifiAdapterBuilder;
    }
}