using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Shell;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Augur : ShipBase
{
    public Augur(bool photonDeflectors = false)
        : base(
            new ImpulseEngineTypeE(),
            new JumpingEngineTypeAlpha(),
            new DeflectorThirdType(photonDeflectors),
            new ShellThirdType(),
            false,
            BigWeightDimensionalCharacteristics)
    {
    }
}