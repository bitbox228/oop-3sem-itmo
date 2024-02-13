using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerAttributesCollections;

public class RamFormFactorsList
{
    private readonly List<string> _ramFormFactorsNames;

    public RamFormFactorsList()
    {
        _ramFormFactorsNames = new List<string>()
        {
            "SIMM",
            "DIMM",
            "FB-DIMM",
            "SODIMM",
            "MicroDIMM",
            "RIMM",
        };
    }

    public bool Contains(string name)
    {
        return
            !string.IsNullOrEmpty(name) &&
            _ramFormFactorsNames.Contains(name);
    }
}