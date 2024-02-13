using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.RepositoryInitializers;

public class GraphicsCardInitializer : IRepositoryInitializer
{
    public void Initialize(ComputerComponentsRepository repository)
    {
        repository = repository ?? throw new ArgumentNullException(nameof(repository));

        var graphicsCardBuilder = new GraphicsCardBuilder();

        graphicsCardBuilder
            .WithName(new string("MSI GeForce RTX 4060 GAMING X"))
            .WithVideoMemorySize(8)
            .WithPcieVersion(16)
            .WithChipFrequency(1830)
            .WithPowerConsumption(115)
            .WithLength(247)
            .WithWidth(130);

        repository.GraphicsCardRepository
            .AddComponent(graphicsCardBuilder.Build());

        graphicsCardBuilder.Reset();

        graphicsCardBuilder
            .WithName(new string("NVIDIA SUPER MEGA GTX 8090 TI ULTRA MEGA SUPER"))
            .WithVideoMemorySize(256)
            .WithPcieVersion(16)
            .WithChipFrequency(10000)
            .WithPowerConsumption(463)
            .WithLength(100)
            .WithWidth(50);

        repository.GraphicsCardRepository
            .AddComponent(graphicsCardBuilder.Build());

        graphicsCardBuilder.Reset();

        graphicsCardBuilder
            .WithName(new string("BIG MSI GeForce RTX 4060 GAMING X"))
            .WithVideoMemorySize(8)
            .WithPcieVersion(16)
            .WithChipFrequency(1830)
            .WithPowerConsumption(115)
            .WithLength(400)
            .WithWidth(200);

        repository.GraphicsCardRepository
            .AddComponent(graphicsCardBuilder.Build());
    }
}