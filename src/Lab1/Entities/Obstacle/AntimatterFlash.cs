using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class AntimatterFlash : ObstacleBase
{
    private const int AntimatterFlashDamage = 1;

    public AntimatterFlash()
    {
        Damage = AntimatterFlashDamage;
    }

    public override void Collision(ShipBase ship)
    {
        if (ship is null) return;
        ship.Collision(this);
    }
}