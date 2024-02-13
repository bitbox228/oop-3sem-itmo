using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerValidator;

public interface IComputerValidator
{
    ComponentsValidationResult Validate(Pc pc);
}