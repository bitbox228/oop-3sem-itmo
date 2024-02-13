using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerAttributesCollections;

public class WifiStandardsList
{
    private readonly List<string> _wifiStandardsList;

    public WifiStandardsList()
    {
        _wifiStandardsList = new List<string>()
        {
            "802.11a",
            "802.11ac",
            "802.11b",
            "802.11g",
            "802.11n",
            "802.11b",
            "802.11g",
            "802.11n",
            "802.11ax",
        };
    }

    public bool Contains(string name)
    {
        return
            !string.IsNullOrEmpty(name) &&
            _wifiStandardsList.Contains(name);
    }
}