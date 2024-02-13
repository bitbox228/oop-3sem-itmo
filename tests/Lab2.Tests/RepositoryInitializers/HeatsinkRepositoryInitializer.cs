using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.RepositoryInitializers;

public class HeatsinkRepositoryInitializer : IRepositoryInitializer
{
    public void Initialize(ComputerComponentsRepository repository)
    {
        repository = repository ?? throw new ArgumentNullException(nameof(repository));

        var heatsinkBuilder = new HeatsinkBuilder();

        heatsinkBuilder
            .WithName(new string("DEEPCOOL GAMMAXX 300 FURY"))
            .WithDimensions(new Dimensions(121, 77, 130))
            .AddSupportedSocket(new CpuSocket(new string("AM1")))
            .AddSupportedSocket(new CpuSocket(new string("AM2")))
            .AddSupportedSocket(new CpuSocket(new string("AM3")))
            .AddSupportedSocket(new CpuSocket(new string("AM4")))
            .AddSupportedSocket(new CpuSocket(new string("AM5")))
            .WithTdp(130);

        repository.HeatsinkRepository
            .AddComponent(heatsinkBuilder.Build());

        heatsinkBuilder.Reset();

        heatsinkBuilder
            .WithName(new string("VERY WEAK HEATSINK"))
            .WithDimensions(new Dimensions(10, 19, 27))
            .AddSupportedSocket(new CpuSocket(new string("AM1")))
            .AddSupportedSocket(new CpuSocket(new string("AM2")))
            .AddSupportedSocket(new CpuSocket(new string("AM3")))
            .AddSupportedSocket(new CpuSocket(new string("AM4")))
            .WithTdp(15);

        repository.HeatsinkRepository
            .AddComponent(heatsinkBuilder.Build());

        heatsinkBuilder.Reset();

        heatsinkBuilder
            .WithName(new string("Heatsink not for INTEL"))
            .WithDimensions(new Dimensions(10, 19, 27))
            .AddSupportedSocket(new CpuSocket(new string("AM1")))
            .AddSupportedSocket(new CpuSocket(new string("AM2")))
            .AddSupportedSocket(new CpuSocket(new string("AM3")))
            .AddSupportedSocket(new CpuSocket(new string("AM4")))
            .WithTdp(280);

        repository.HeatsinkRepository
            .AddComponent(heatsinkBuilder.Build());

        heatsinkBuilder.Reset();

        heatsinkBuilder
            .WithName(new string("DEEPCOOL GAMMAX 300B"))
            .WithDimensions(new Dimensions(121, 77, 135))
            .AddSupportedSocket(new CpuSocket(new string("AM4")))
            .AddSupportedSocket(new CpuSocket(new string("AM5")))
            .AddSupportedSocket(new CpuSocket(new string("LGA 1700")))
            .AddSupportedSocket(new CpuSocket(new string("LGA 1200")))
            .WithTdp(260);

        repository.HeatsinkRepository
            .AddComponent(heatsinkBuilder.Build());
    }
}