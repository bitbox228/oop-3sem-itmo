namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ResultTypes;

public abstract record ComponentsValidationResult
{
    private ComponentsValidationResult() { }

    public sealed record Success : ComponentsValidationResult;

    public sealed record WarrantyDisclaimer : ComponentsValidationResult;

    public sealed record PowerConsumptionWarning : ComponentsValidationResult;

    public sealed record IncompatibleComputerComponents(string Comment)
        : ComponentsValidationResult;

    public sealed record NoMandatoryComponent(string Comment)
        : ComponentsValidationResult;
}