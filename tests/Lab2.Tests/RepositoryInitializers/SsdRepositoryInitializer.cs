using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.RepositoryInitializers;

public class SsdRepositoryInitializer : IRepositoryInitializer
{
    public void Initialize(ComputerComponentsRepository repository)
    {
        repository = repository ?? throw new ArgumentNullException(nameof(repository));

        var ssdBuilder = new SsdBuilder();

        ssdBuilder
            .WithName(new string("MSI SPATIUM M450"))
            .WithConnectionType(new ConnectionType.Pcie(4))
            .WithMemorySize(500)
            .WithMaxOperatingSpeed(2300)
            .WithPowerConsumption(3);

        repository.SsdRepository
            .AddComponent(ssdBuilder.Build());
    }
}