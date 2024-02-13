using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;

public interface ICpuBuilder
{
    ICpuBuilder WithName(string name);

    ICpuBuilder WithCoreFrequency(double coreFrequency);

    ICpuBuilder WithCoreCount(int coreCount);

    ICpuBuilder WithCpuSocket(CpuSocket cpuSocket);

    ICpuBuilder WithGraphicsCore(bool graphicsCore);

    ICpuBuilder WithRamFrequency(RamFrequency ramFrequency);

    ICpuBuilder WithTdp(int tdp);

    ICpuBuilder WithPowerConsumption(int powerConsumption);

    void Reset();

    Cpu Build();
}