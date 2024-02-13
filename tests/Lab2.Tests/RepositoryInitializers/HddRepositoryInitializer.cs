using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.RepositoryInitializers;

public class HddRepositoryInitializer : IRepositoryInitializer
{
    public void Initialize(ComputerComponentsRepository repository)
    {
        repository = repository ?? throw new ArgumentNullException(nameof(repository));

        var hddBuilder = new HddBuilder();

        hddBuilder
            .WithName(new string("Toshiba P300"))
            .WithMemorySize(1024)
            .WithSpindleSpeed(7200)
            .WithPowerConsumption(6);

        repository.HddRepository
            .AddComponent(hddBuilder.Build());
    }
}