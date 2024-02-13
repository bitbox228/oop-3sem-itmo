using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.RepositoryInitializers;

public class RamRepositoryInitializer : IRepositoryInitializer
{
    public void Initialize(ComputerComponentsRepository repository)
    {
        repository = repository ?? throw new ArgumentNullException(nameof(repository));

        var ramBuilder = new RamBuilder();

        ramBuilder
            .WithName(new string("AMD Radeon R9 Gamer Series"))
            .WithMemorySize(16)
            .AddSupportedJedec(
                new Jedec(
                    3200,
                    new RamTimings(16, 18, 18, 39)))
            .AddSupportedVoltage(100)
            .AddXmpProfile(
                new XmpProfile(
                    new RamTimings(16, 18, 18, 39),
                    100,
                    3200))
            .WithRamFormFactor(new RamFormFactor(new string("DIMM")))
            .WithDdrStandart(new DdrStandard(new string("DDR4")))
            .WithPowerConsumption(5);

        repository.RamRepository
            .AddComponent(ramBuilder.Build());
    }
}