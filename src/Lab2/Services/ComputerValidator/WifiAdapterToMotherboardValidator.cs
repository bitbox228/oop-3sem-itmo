using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerValidator;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class WifiAdapterToMotherboardValidator : IComputerValidator
{
    private const string Comment = "Network hardware conflict.";

    public ComponentsValidationResult Validate(Pc pc)
    {
        pc = pc ?? throw new ArgumentNullException(nameof(pc));

        if (pc.WifiAdapter is not null && pc.Motherboard.WifiModule)
        {
            return new ComponentsValidationResult.IncompatibleComputerComponents(Comment);
        }

        return new ComponentsValidationResult.Success();
    }
}