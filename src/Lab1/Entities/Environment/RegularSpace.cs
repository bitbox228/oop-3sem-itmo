using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public class RegularSpace : EnvironmentBase
{
    public RegularSpace(
        double distance,
        IReadOnlyCollection<ObstacleBase>? obstacles)
        : base(
            distance,
            obstacles)
    {
        if (obstacles is null) return;
        bool allFromRegularSpace = obstacles.All(
            obstacle => obstacle is (Asteroid or Meteorite));
        if (!allFromRegularSpace)
        {
            throw new InvalidObstacleOnEnvironmentException("Obstacle is not Asteroid or Meteorite.");
        }
    }

    public override RouteResult Pass(ShipBase ship, RouteResult routeResult)
    {
        ship = ship ?? throw new ArgumentNullException(nameof(ship));
        routeResult = routeResult ?? throw new ArgumentNullException(nameof(routeResult));

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