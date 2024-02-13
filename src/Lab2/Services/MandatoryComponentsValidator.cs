using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class MandatoryComponentsValidator
{
    public ComponentsValidationResult Validate(
        Motherboard? motherboard,
        Cpu? cpu,
        Heatsink? heatsink,
        ComputerCase? computerCase,
        Psu? psu)
    {
        if (motherboard is null) return new ComponentsValidationResult.NoMandatoryComponent("No motherboard.");

        if (cpu is null) return new ComponentsValidationResult.NoMandatoryComponent("No CPU.");

        if (heatsink is null) return new ComponentsValidationResult.NoMandatoryComponent("No heatsink.");

        if (computerCase is null) return new ComponentsValidationResult.NoMandatoryComponent("No computer case.");

        if (psu is null) return new ComponentsValidationResult.NoMandatoryComponent("No PSU.");

        return new ComponentsValidationResult.Success();
    }
}