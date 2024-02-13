using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsDebuilders;

public interface ICpuDebuilder
{
    ICpuBuilder Debuild(ICpuBuilder cpuBuilder);
}