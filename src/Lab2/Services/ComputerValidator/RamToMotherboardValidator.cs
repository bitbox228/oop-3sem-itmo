using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerValidator;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class RamToMotherboardValidator : IComputerValidator
{
    private const string Comment = "Motherboard doesn't support RAM.";

    public ComponentsValidationResult Validate(Pc pc)
    {
        pc = pc ?? throw new ArgumentNullException(nameof(pc));

        if (pc.Motherboard.RamSlotsCount < pc.RamSticks.Count)
        {
            return
                new ComponentsValidationResult.IncompatibleComputerComponents(Comment);
        }

        foreach (Ram ramStick in pc.RamSticks)
        {
            if (!pc.Motherboard.DdrStandard.Equals(ramStick.DdrStandard))
            {
                return
                    new ComponentsValidationResult.IncompatibleComputerComponents(Comment);
            }

            XmpProfile? xmpProfile = pc.Motherboard.MotherboardChipset.SupportedXmpProfiles
                .FirstOrDefault(xmpProfile => ramStick.SupportedXmpProfiles
                    .Contains(xmpProfile));

            if (xmpProfile is null)
            {
                return
                    new ComponentsValidationResult.IncompatibleComputerComponents(Comment);
            }
        }

        return new ComponentsValidationResult.Success();
    }
}