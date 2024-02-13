using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.RepositoryInitializers;

public class WifiAdapterRepositoryInitializer : IRepositoryInitializer
{
    public void Initialize(ComputerComponentsRepository repository)
    {
        repository = repository ?? throw new ArgumentNullException(nameof(repository));

        var wifiAdapterBuilder = new WifiAdapterBuilder();

        wifiAdapterBuilder
            .WithName("TP-LINK Archer T2E")
            .WithWifiStandardVersion(new WifiStandardVersion("802.11n"))
            .WithBluetoothModule(false)
            .WithPcieVersion(1)
            .WithPowerConsumption(2);

        repository.WifiAdapterRepository
            .AddComponent(wifiAdapterBuilder.Build());
    }
}