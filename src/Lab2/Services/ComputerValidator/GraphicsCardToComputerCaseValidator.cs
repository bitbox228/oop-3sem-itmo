using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerValidator;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class GraphicsCardToComputerCaseValidator : IComputerValidator
{
    private const string Comment = "Graphics card doesn't fit in the computer case.";

    public ComponentsValidationResult Validate(Pc pc)
    {
        pc = pc ?? throw new ArgumentNullException(nameof(pc));

        if (pc.GraphicsCard is null)
        {
            return new ComponentsValidationResult.Success();
        }

        if (pc.GraphicsCard.Length <= pc.ComputerCase.MaxGraphicsCardLength &&
            pc.GraphicsCard.Width <= pc.ComputerCase.MaxGraphicsCardWidth)
        {
            return new ComponentsValidationResult.Success();
        }

        return new ComponentsValidationResult.IncompatibleComputerComponents(Comment);
    }
}