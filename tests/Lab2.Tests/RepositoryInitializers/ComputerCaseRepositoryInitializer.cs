using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.RepositoryInitializers;

public class ComputerCaseRepositoryInitializer : IRepositoryInitializer
{
    public void Initialize(ComputerComponentsRepository repository)
    {
        repository = repository ?? throw new ArgumentNullException(nameof(repository));

        var computerCaseBuilder = new ComputerCaseBuilder();

        computerCaseBuilder
            .WithName("Cougar MX330-G")
            .WithMaxGraphicsCardLength(350)
            .WithMaxGraphicsCardWidth(200)
            .AddSupportedMotherboardFormFactor(
                new MotherboardFormFactor(new string("Micro-ATX")))
            .AddSupportedMotherboardFormFactor(
                new MotherboardFormFactor(new string("Mini-ITX")))
            .AddSupportedMotherboardFormFactor(
                new MotherboardFormFactor(new string("Standard-ATX")))
            .WithDimensions(new Dimensions(195, 427, 473));

        repository.ComputerCaseRepository
            .AddComponent(computerCaseBuilder.Build());
    }
}