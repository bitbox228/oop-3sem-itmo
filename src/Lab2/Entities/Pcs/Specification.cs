using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;

public class Specification
{
    public Specification()
    {
        RamStickNames = new Collection<string>();
        SsdDiskNames = new Collection<string>();
        HddDiskNames = new Collection<string>();
    }

    public string? MotherboardName { get; set; }
    public string? CpuName { get; set; }
    public string? HeatsinkName { get; set; }
    public Collection<string> RamStickNames { get; }
    public string? GraphicsCardName { get; set; }
    public Collection<string> SsdDiskNames { get; }
    public Collection<string> HddDiskNames { get; }
    public string? ComputerCaseName { get; set; }
    public string? PsuName { get; set; }
    public string? WifiAdapterName { get; set; }
}