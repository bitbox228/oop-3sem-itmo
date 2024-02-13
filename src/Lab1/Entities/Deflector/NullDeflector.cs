using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class NullDeflector : DeflectorBase
{
    public NullDeflector()
    {
        HitPoints = 0;
        PhotonHitPoints = 0;
    }

    public override void TakeDamage(ObstacleBase? obstacle)
    {
    }

    public override void TakeDamage(AntimatterFlash obstacle)
    {
    }
}