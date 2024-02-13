using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class DeflectorSecondType : DeflectorBase
{
    private const int DefaultDeflectorType2HitPoints = 10;

    public DeflectorSecondType(bool placePhotonDeflectors = false)
    {
        HitPoints = DefaultDeflectorType2HitPoints;
        PhotonHitPoints = placePhotonDeflectors ? DefaultPhotonHitPoints : 0;
    }

    public override void TakeDamage(ObstacleBase? obstacle)
    {
        if (obstacle is null) return;
        int actual = HitPoints > obstacle.Damage ? obstacle.Damage : HitPoints;
        HitPoints -= actual;
        obstacle.TakeDamage(actual);
    }

    public override void TakeDamage(AntimatterFlash obstacle)
    {
        if (obstacle is null) return;
        int actual = PhotonHitPoints > obstacle.Damage ? obstacle.Damage : PhotonHitPoints;
        PhotonHitPoints -= actual;
        obstacle.TakeDamage(actual);
    }
}