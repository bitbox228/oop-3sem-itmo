namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class ImpulseEngineTypeC : ImpulseEngineBase
{
    private const double ImpulseEngineTypeCSpeed = 50;
    private const double ImpulseEngineTypeCFuelConsumption = 78;
    private const double ImpulseEngineTypeCStartFuelConsumption = 20;

    public ImpulseEngineTypeC()
        : base(
            ImpulseEngineTypeCSpeed,
            ImpulseEngineTypeCFuelConsumption,
            ImpulseEngineTypeCStartFuelConsumption)
    {
    }
}