using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Shell;

public class ShellSecondType : ShellBase
{
    public ShellSecondType()
    {
        HitPoints = 5;
    }

    public override void TakeDamage(ObstacleBase? obstacle)
    {
    }

    public override void TakeDamage(Meteorite obstacle)
    {
        if (obstacle is null) return;
        int actual = HitPoints > obstacle.Damage ? obstacle.Damage : HitPoints;
        HitPoints -= actual;
        obstacle.TakeDamage(actual);
    }

    public override void TakeDamage(Asteroid obstacle)
    {
        if (obstacle is null) return;
        int actual = HitPoints > obstacle.Damage ? obstacle.Damage : HitPoints;
        HitPoints -= actual;
        obstacle.TakeDamage(actual);
    }
}