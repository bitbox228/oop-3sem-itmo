using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;

public interface IMotherboardBuilder
{
    IMotherboardBuilder WithName(string name);

    IMotherboardBuilder WithCpuSocket(CpuSocket cpuSocket);

    IMotherboardBuilder AddPciePort(Pcie pcie);

    IMotherboardBuilder WithSataPorts(int sataPortsCount);

    IMotherboardBuilder WithMotherboardChipset(MotherboardChipset motherboardChipset);

    IMotherboardBuilder WithDdrStandard(DdrStandard ddrStandard);

    IMotherboardBuilder WithRamSlots(int ramSlotsCount);

    IMotherboardBuilder WithMotherboardFormFactor(MotherboardFormFactor motherboardFormFactor);

    IMotherboardBuilder WithBios(Bios bios);

    IMotherboardBuilder WithWifiModule(bool wifiModule);

    void Reset();

    Motherboard Build();
}