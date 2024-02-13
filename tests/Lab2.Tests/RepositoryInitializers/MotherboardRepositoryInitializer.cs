using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.RepositoryInitializers;

public class MotherboardRepositoryInitializer : IRepositoryInitializer
{
    public void Initialize(ComputerComponentsRepository repository)
    {
        repository = repository ?? throw new ArgumentNullException(nameof(repository));

        var motherboardBuilder = new MotherboardBuilder();

        var supportedCpus = new List<Cpu>
        {
            repository.CpuRepository.FindComponentByName("AMD Ryzen 7 5700X OEM")
            ?? throw new ArgumentNullException(nameof(repository)),
        };

        motherboardBuilder
            .WithName("MSI MAG B550 TOMAHAWK")
            .WithCpuSocket(new CpuSocket("AM4"))
            .AddPciePort(new Pcie(16, 2))
            .AddPciePort(new Pcie(4, 1))
            .AddPciePort(new Pcie(1, 1))
            .WithSataPorts(6)
            .WithMotherboardChipset(new MotherboardChipset(
                new RamFrequency(50, 150),
                new[]
                {
                    new XmpProfile(
                        new RamTimings(16, 18, 18, 39),
                        100,
                        3200),
                }))
            .WithDdrStandard(new DdrStandard("DDR4"))
            .WithRamSlots(4)
            .WithMotherboardFormFactor(new MotherboardFormFactor("Standard-ATX"))
            .WithBios(new Bios(
                new string("7C91"),
                new string("A2"),
                supportedCpus))
            .WithWifiModule(false);

        repository.MotherboardRepository
            .AddComponent(motherboardBuilder.Build());

        motherboardBuilder.Reset();
        supportedCpus.Clear();
        supportedCpus.Add(repository.CpuRepository.FindComponentByName("Intel Core i9-13900K OEM")
                          ?? throw new ArgumentNullException(nameof(repository)));

        motherboardBuilder
            .WithName("MSI MAG Z690 TOMAHAWK")
            .WithCpuSocket(new CpuSocket("LGA 1700"))
            .AddPciePort(new Pcie(16, 2))
            .AddPciePort(new Pcie(4, 1))
            .AddPciePort(new Pcie(1, 1))
            .WithSataPorts(6)
            .WithMotherboardChipset(new MotherboardChipset(
                new RamFrequency(50, 150),
                new[]
                {
                    new XmpProfile(
                        new RamTimings(16, 18, 18, 39),
                        100,
                        3200),
                }))
            .WithDdrStandard(new DdrStandard("DDR4"))
            .WithRamSlots(4)
            .WithMotherboardFormFactor(new MotherboardFormFactor("Standard-ATX"))
            .WithBios(new Bios(
                new string("7C91"),
                new string("A2"),
                supportedCpus))
            .WithWifiModule(false);

        repository.MotherboardRepository
            .AddComponent(motherboardBuilder.Build());
    }
}