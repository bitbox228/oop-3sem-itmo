using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

public class Pcie
{
    public Pcie(
        int pcieVersion,
        int count)
    {
        if (pcieVersion < 0) throw new NegativeValueException(nameof(pcieVersion));
        if (count < 0) throw new NegativeValueException(nameof(count));

        PcieVersion = pcieVersion;
        Count = count;
    }

    public int PcieVersion { get; }
    public int Count { get; set; }
}