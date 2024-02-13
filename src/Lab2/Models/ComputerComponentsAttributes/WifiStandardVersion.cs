using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerAttributesCollections;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

public class WifiStandardVersion
{
    public WifiStandardVersion(string name)
    {
        var wifiStandardsList = new WifiStandardsList();
        if (!wifiStandardsList.Contains(name))
            throw new InvalidAttributeNameException(nameof(WifiStandardVersion), name);

        Name = name;
    }

    public string Name { get; }
}