using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.PcBuilder;

public interface IPcBuilder
{
    IPcBuilder WithMotherBoard(Motherboard motherboard);

    IPcBuilder WithCpu(Cpu cpu);

    IPcBuilder WithHeatsink(Heatsink heatsink);

    IPcBuilder AddRam(Ram ram);

    IPcBuilder WithGraphicsCard(GraphicsCard graphicsCard);

    IPcBuilder AddSsd(Ssd ssd);

    IPcBuilder AddHdd(Hdd hdd);

    IPcBuilder WithComputerCase(ComputerCase computerCase);

    IPcBuilder WithPsu(Psu psu);

    IPcBuilder WithWifiAdapter(WifiAdapter wifiAdapter);

    void Reset();

    PcBuildResult Build();
}