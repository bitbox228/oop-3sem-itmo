using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

public class MotherboardChipset
{
    public MotherboardChipset(
        RamFrequency ramFrequency,
        IEnumerable<XmpProfile> supportedXmpProfiles)
    {
        ramFrequency = ramFrequency ?? throw new ArgumentNullException(nameof(ramFrequency));

        RamFrequency = ramFrequency;
        supportedXmpProfiles = supportedXmpProfiles ?? throw new ArgumentNullException(nameof(supportedXmpProfiles));
        SupportedXmpProfiles = supportedXmpProfiles.ToArray();

        if (SupportedXmpProfiles.Any(supportedXmpProfile => supportedXmpProfile is null))
        {
            throw new ArgumentNullException(nameof(supportedXmpProfiles));
        }
    }

    public RamFrequency RamFrequency { get; }
    public IReadOnlyCollection<XmpProfile> SupportedXmpProfiles { get; }
}