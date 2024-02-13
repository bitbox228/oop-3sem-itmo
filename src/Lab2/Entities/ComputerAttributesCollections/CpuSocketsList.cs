using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerAttributesCollections;

public class CpuSocketsList
{
    private readonly List<string> _cpuSocketsNames;

    public CpuSocketsList()
    {
        _cpuSocketsNames = new List<string>()
        {
            "LGA771",
            "LGA775",
            "LGA1156",
            "LGA1155",
            "LGA2011",
            "LGA1356",
            "LGA1150",
            "LGA2011-3",
            "LGA 1151",
            "LGA 2066",
            "LGA 1200",
            "LGA 1700",
            "LGA 1851",
            "AM1",
            "AM2",
            "AM2+",
            "AM3",
            "AM3+",
            "AM4",
            "FM1",
            "FM2",
            "FM2+",
            "TR4",
            "sTRX4",
            "sWRX8",
            "AM5",
        };
    }

    public bool Contains(string name)
    {
        return
            !string.IsNullOrEmpty(name) &&
            _cpuSocketsNames.Contains(name);
    }
}