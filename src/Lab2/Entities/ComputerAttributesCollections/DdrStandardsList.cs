using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerAttributesCollections;

public class DdrStandardsList
{
    private readonly List<string> _ddrStandardsList;

    public DdrStandardsList()
    {
        _ddrStandardsList = new List<string>()
        {
            "DDR",
            "DDR2",
            "DDR3",
            "DDR4",
            "DDR5",
        };
    }

    public bool Contains(string name)
    {
        return
            !string.IsNullOrEmpty(name) &&
            _ddrStandardsList.Contains(name);
    }
}