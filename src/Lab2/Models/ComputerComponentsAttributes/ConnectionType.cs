namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

public abstract record ConnectionType
{
    private ConnectionType() { }

    public sealed record Pcie(int PcieVersion) : ConnectionType;

    public sealed record Sata : ConnectionType;
}