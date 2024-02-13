using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerAttributesCollections;

public class MotherboardFormFactorsList
{
    private readonly List<string> _motherboardFormFactorsNames;

    public MotherboardFormFactorsList()
    {
        _motherboardFormFactorsNames = new List<string>()
        {
            "Standard-ATX",
            "ATX",
            "Micro-ATX",
            "Mini-ITX",
            "Nano-ITX",
            "Pico-ITX",
            "Flex-ATX",
            "NLX",
            "WTX",
            "CEB",
        };
    }

    public bool Contains(string name)
    {
        return
            !string.IsNullOrEmpty(name) &&
            _motherboardFormFactorsNames.Contains(name);
    }
}