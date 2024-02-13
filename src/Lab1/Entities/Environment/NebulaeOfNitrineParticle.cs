using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public class NebulaeOfNitrineParticle : EnvironmentBase
{
    public NebulaeOfNitrineParticle(
        double distance,
        IReadOnlyCollection<ObstacleBase>? obstacles)
        : base(
            distance,
            obstacles)
    {
        if (obstacles is null) return;
        bool allFromNebulaeOfNitrineParticle = obstacles.All(
            obstacle => obstacle is SpaceWhales);
        if (!allFromNebulaeOfNitrineParticle)
        {
            throw new InvalidObstacleOnEnvironmentException("Obstacle is not Space Whales.");
        }
    }

    public override RouteResult Pass(ShipBase ship, RouteResult routeResult)
    {
        ship = ship ?? throw new ArgumentNullException(nameof(ship));
        routeResult = routeResult ?? throw new ArgumentNullException(nameof(routeResult));

        if (ship.ImpulseEngine is not ImpulseEngineTypeE) return new RouteResult.ShipLost();

        if (routeResult is not RouteResult.Success) return routeResult;

        double time = ship.ImpulseEngine.CalculateTime(Distance);
        double fuel = ship.ImpulseEngine.CalculateFuel(Distance);

        var successRouteResult = (RouteResult.Success)routeResult;
        successRouteResult.Time += time;
        successRouteResult.Fuel += fuel;

        if (Obstacles is null) return routeResult;

        foreach (ObstacleBase obstacle in Obstacles)
        {
            obstacle.Collision(ship);
        }

        if (ship.IsShipDead)
        {
            return new RouteResult.ShipDead();
        }

        if (ship.IsCrewDead)
        {
            return new RouteResult.CrewDead();
        }

        return routeResult;
    }
}