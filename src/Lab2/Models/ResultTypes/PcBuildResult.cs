using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ResultTypes;

public abstract record PcBuildResult
{
    private PcBuildResult() { }

    public sealed record Success(Pc Pc) : PcBuildResult;

    public sealed record WarrantyDisclaimer(Pc Pc) : PcBuildResult;

    public sealed record PowerConsumptionWarning(Pc Pc) : PcBuildResult;

    public sealed record IncompatibleComputerComponents(string Comment) : PcBuildResult;

    public sealed record NoMandatoryComponent(string Comment) : PcBuildResult;
}