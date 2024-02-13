using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Shell;

public abstract class ShellBase
{
    protected int HitPoints { get; set; }

    public abstract void TakeDamage(ObstacleBase? obstacle);

    public abstract void TakeDamage(Asteroid obstacle);

    public abstract void TakeDamage(Meteorite obstacle);
}