using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerValidator;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class CpuToMotherboardValidator : IComputerValidator
{
    private const string Comment = "Incompatible Motherboard and CPU sockets.";

    public ComponentsValidationResult Validate(Pc pc)
    {
        pc = pc ?? throw new ArgumentNullException(nameof(pc));

        if (!pc.Motherboard.CpuSocket.Equals(pc.Cpu.CpuSocket))
        {
            return new ComponentsValidationResult.IncompatibleComputerComponents(Comment);
        }

        return new ComponentsValidationResult.Success();
    }
}