using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.PcBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;

public class PcDirectorBuilder : IPcDirectorBuilder
{
    public IPcBuilder Direct(
        IPcBuilder pcBuilder,
        Specification specification,
        ComputerComponentsRepository repository)
    {
        pcBuilder = pcBuilder ??
                    throw new ArgumentNullException(nameof(pcBuilder));
        specification = specification ??
                        throw new ArgumentNullException(nameof(specification));
        repository = repository ??
                     throw new ArgumentNullException(nameof(repository));

        pcBuilder.Reset();

        if (specification.MotherboardName is not null)
        {
            Motherboard motherBoard =
                repository.MotherboardRepository.FindComponentByName(specification.MotherboardName) ??
                throw new InvalidComponentNameException(nameof(Motherboard));
            pcBuilder.WithMotherBoard(motherBoard);
        }

        if (specification.CpuName is not null)
        {
            Cpu cpu =
                repository.CpuRepository.FindComponentByName(specification.CpuName) ??
                throw new InvalidComponentNameException(nameof(Cpu));
            pcBuilder.WithCpu(cpu);
        }

        if (specification.HeatsinkName is not null)
        {
            Heatsink heatsink =
                repository.HeatsinkRepository.FindComponentByName(specification.HeatsinkName) ??
                throw new InvalidComponentNameException(nameof(Heatsink));
            pcBuilder.WithHeatsink(heatsink);
        }

        foreach (string ramStickName in specification.RamStickNames)
        {
            Ram ram =
                repository.RamRepository.FindComponentByName(ramStickName) ??
                throw new InvalidComponentNameException(nameof(Ram));
            pcBuilder.AddRam(ram);
        }

        if (specification.GraphicsCardName is not null)
        {
            GraphicsCard graphicsCard =
                repository.GraphicsCardRepository.FindComponentByName(specification.GraphicsCardName) ??
                throw new InvalidComponentNameException(nameof(GraphicsCard));
            pcBuilder.WithGraphicsCard(graphicsCard);
        }

        foreach (string ssdDiskName in specification.SsdDiskNames)
        {
            Ssd ssd =
                repository.SsdRepository.FindComponentByName(ssdDiskName) ??
                throw new InvalidComponentNameException(nameof(Ssd));
            pcBuilder.AddSsd(ssd);
        }

        foreach (string hddDiskName in specification.HddDiskNames)
        {
            Hdd hdd =
                repository.HddRepository.FindComponentByName(hddDiskName) ??
                throw new InvalidComponentNameException(nameof(Hdd));
            pcBuilder.AddHdd(hdd);
        }

        if (specification.ComputerCaseName is not null)
        {
            ComputerCase computerCase =
                repository.ComputerCaseRepository.FindComponentByName(specification.ComputerCaseName) ??
                throw new InvalidComponentNameException(nameof(ComputerCase));
            pcBuilder.WithComputerCase(computerCase);
        }

        if (specification.PsuName is not null)
        {
            Psu psu =
                repository.PsuRepository.FindComponentByName(specification.PsuName) ??
                throw new InvalidComponentNameException(nameof(Psu));
            pcBuilder.WithPsu(psu);
        }

        if (specification.WifiAdapterName is not null)
        {
            WifiAdapter wifiAdapter =
                repository.WifiAdapterRepository.FindComponentByName(specification.WifiAdapterName) ??
                throw new InvalidComponentNameException(nameof(WifiAdapter));
            pcBuilder.WithWifiAdapter(wifiAdapter);
        }

        return pcBuilder;
    }
}