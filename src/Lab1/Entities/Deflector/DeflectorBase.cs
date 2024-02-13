using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public abstract class DeflectorBase
{
    protected const int DefaultPhotonHitPoints = 3;

    public int HitPoints { get; protected set; }

    protected int PhotonHitPoints { get; set; }

    public abstract void TakeDamage(ObstacleBase? obstacle);

    public abstract void TakeDamage(AntimatterFlash obstacle);
}