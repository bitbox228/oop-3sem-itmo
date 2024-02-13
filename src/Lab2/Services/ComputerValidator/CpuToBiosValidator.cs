using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerValidator;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class CpuToBiosValidator : IComputerValidator
{
    private const string Comment = "CPU is not supported by BIOS.";

    public ComponentsValidationResult Validate(Pc pc)
    {
        pc = pc ?? throw new ArgumentNullException(nameof(pc));

        Cpu? supportedCpu = pc.Motherboard.Bios.SupportedCpus
            .FirstOrDefault(supportedCpu => supportedCpu.Equals(pc.Cpu));

        if (supportedCpu is null)
        {
            return
                new ComponentsValidationResult.IncompatibleComputerComponents(Comment);
        }

        return new ComponentsValidationResult.Success();
    }
}