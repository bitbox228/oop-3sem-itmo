using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerValidator;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class RamSticksValidator : IComputerValidator
{
    private const string Comment = "PC should contain at least one RAM stick.";

    public ComponentsValidationResult Validate(Pc pc)
    {
        pc = pc ?? throw new ArgumentNullException(nameof(pc));

        if (pc.RamSticks.Count == 0)
        {
            return new ComponentsValidationResult.NoMandatoryComponent(Comment);
        }

        return new ComponentsValidationResult.Success();
    }
}