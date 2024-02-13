namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class NullJumpingEngine : JumpingEngineBase
{
    public NullJumpingEngine()
        : base(0)
    {
    }

    public override double CalculateFuel(double distance)
    {
        throw new System.NotImplementedException();
    }
}