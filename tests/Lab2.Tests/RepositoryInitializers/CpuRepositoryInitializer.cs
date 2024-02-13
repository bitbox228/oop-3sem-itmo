using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.RepositoryInitializers;

public class CpuRepositoryInitializer : IRepositoryInitializer
{
    public void Initialize(ComputerComponentsRepository repository)
    {
        repository = repository ?? throw new ArgumentNullException(nameof(repository));

        var cpuBuilder = new CpuBuilder();

        cpuBuilder
            .WithName(new string("AMD Ryzen 7 5700X OEM"))
            .WithCoreFrequency(3.4)
            .WithCoreCount(8)
            .WithCpuSocket(new CpuSocket("AM4"))
            .WithGraphicsCore(false)
            .WithRamFrequency(new RamFrequency(1500, 3200))
            .WithTdp(65)
            .WithPowerConsumption(65);

        repository.CpuRepository
            .AddComponent(cpuBuilder.Build());

        cpuBuilder.Reset();

        cpuBuilder
            .WithName(new string("Intel Core i9-13900K OEM"))
            .WithCoreFrequency(3)
            .WithCoreCount(24)
            .WithCpuSocket(new CpuSocket("LGA 1700"))
            .WithGraphicsCore(true)
            .WithRamFrequency(new RamFrequency(1500, 5600))
            .WithTdp(253)
            .WithPowerConsumption(125);

        repository.CpuRepository
            .AddComponent(cpuBuilder.Build());
    }
}