using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;

public interface IWifiAdapterBuilder
{
    IWifiAdapterBuilder WithName(string name);

    IWifiAdapterBuilder WithWifiStandardVersion(WifiStandardVersion wifiStandardVersion);

    IWifiAdapterBuilder WithBluetoothModule(bool bluetoothModule);

    IWifiAdapterBuilder WithPcieVersion(int pcieVersion);

    IWifiAdapterBuilder WithPowerConsumption(int powerConsumption);

    void Reset();

    WifiAdapter Build();
}