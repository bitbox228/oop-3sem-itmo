using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerValidator;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class OverallComputerValidator : IComputerValidator
{
    public OverallComputerValidator(IEnumerable<IComputerValidator> validators)
    {
        ComputerValidators = validators.ToArray();
    }

    public IReadOnlyCollection<IComputerValidator> ComputerValidators { get; }

    public ComponentsValidationResult Validate(Pc pc)
    {
        pc = pc ?? throw new ArgumentNullException(nameof(pc));

        var validationResults = ComputerValidators
            .Select(validator => validator.Validate(pc))
            .ToList();

        ComponentsValidationResult? noMandatoryComponentValidationResult = validationResults
            .FirstOrDefault(validationResult => validationResult is ComponentsValidationResult.NoMandatoryComponent);

        if (noMandatoryComponentValidationResult is not null)
            return noMandatoryComponentValidationResult;

        ComponentsValidationResult? incompatibleComputerComponentsValidationResult = validationResults
            .FirstOrDefault(validationResult =>
                validationResult is ComponentsValidationResult.IncompatibleComputerComponents);

        if (incompatibleComputerComponentsValidationResult is not null)
            return incompatibleComputerComponentsValidationResult;

        ComponentsValidationResult? warrantyDisclaimerValidationResult = validationResults
            .FirstOrDefault(validationResult => validationResult is ComponentsValidationResult.WarrantyDisclaimer);

        if (warrantyDisclaimerValidationResult is not null)
            return warrantyDisclaimerValidationResult;

        ComponentsValidationResult? powerConsumptionWarningValidationResult = validationResults
            .FirstOrDefault(validationResult => validationResult is ComponentsValidationResult.PowerConsumptionWarning);

        return powerConsumptionWarningValidationResult ?? new ComponentsValidationResult.Success();
    }
}