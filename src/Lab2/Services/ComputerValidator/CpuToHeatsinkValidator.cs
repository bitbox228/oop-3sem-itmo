using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerValidator;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class CpuToHeatsinkValidator : IComputerValidator
{
    private const string Comment = "Incompatible Heatsink and CPU sockets.";

    public ComponentsValidationResult Validate(Pc pc)
    {
        pc = pc ?? throw new ArgumentNullException(nameof(pc));

        if (!pc.Heatsink.SupportedSockets.Contains(pc.Cpu.CpuSocket))
        {
            return new ComponentsValidationResult.IncompatibleComputerComponents(Comment);
        }

        if (pc.Heatsink.Tdp < pc.Cpu.Tdp)
        {
            return new ComponentsValidationResult.WarrantyDisclaimer();
        }

        return new ComponentsValidationResult.Success();
    }
}