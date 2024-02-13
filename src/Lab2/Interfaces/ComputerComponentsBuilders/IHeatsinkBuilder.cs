using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;

public interface IHeatsinkBuilder
{
    IHeatsinkBuilder WithName(string name);

    IHeatsinkBuilder WithDimensions(Dimensions dimensions);

    IHeatsinkBuilder AddSupportedSocket(CpuSocket cpuSocket);

    IHeatsinkBuilder WithTdp(int tdp);

    void Reset();

    Heatsink Build();
}