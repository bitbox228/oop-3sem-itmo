using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

public class Bios
{
    public Bios(
        string type,
        string version,
        IEnumerable<Cpu> supportedCpus)
    {
        Type = type;
        Version = version;
        SupportedCpus = supportedCpus.ToArray();

        if (SupportedCpus.Any(supportedCpu => supportedCpu is null))
        {
            throw new ArgumentNullException(nameof(supportedCpus));
        }
    }

    public string Type { get; }
    public string Version { get; }
    public IReadOnlyCollection<Cpu> SupportedCpus { get; }
}