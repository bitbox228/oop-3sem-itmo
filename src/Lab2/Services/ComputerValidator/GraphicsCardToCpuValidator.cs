using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerValidator;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class GraphicsCardToCpuValidator : IComputerValidator
{
    private const string Comment = "PC should contain graphics card if there is no graphics core in CPU.";

    public ComponentsValidationResult Validate(Pc pc)
    {
        pc = pc ?? throw new ArgumentNullException(nameof(pc));

        if (!pc.Cpu.GraphicsCore && pc.GraphicsCard is null)
        {
            return new ComponentsValidationResult.NoMandatoryComponent(Comment);
        }

        return new ComponentsValidationResult.Success();
    }
}