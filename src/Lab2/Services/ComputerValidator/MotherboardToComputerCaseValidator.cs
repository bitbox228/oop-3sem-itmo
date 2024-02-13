using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerValidator;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class MotherboardToComputerCaseValidator : IComputerValidator
{
    private const string Comment = "Motherboard doesn't fit in the computer case.";

    public ComponentsValidationResult Validate(Pc pc)
    {
        pc = pc ?? throw new ArgumentNullException(nameof(pc));

        if (pc.ComputerCase.SupportedMotherboardFormFactors.Contains(pc.Motherboard.MotherboardFormFactor))
        {
            return new ComponentsValidationResult.Success();
        }

        return new ComponentsValidationResult.IncompatibleComputerComponents(Comment);
    }
}