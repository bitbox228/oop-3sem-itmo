using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab1.Services.OptimalShipFinder;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ShipTests
{
    [Theory]
    [InlineData(400)]
    public void CheckRouteResultForPleasureShuttleOnNebulaeOfIncreasedDensityFailed(double distance)
    {
        // Arrange
        ShipBase pleasureShuttle = new PleasureShuttle();
        EnvironmentBase nebulaeOfIncreasedDensity = new NebulaeOfIncreasedDensity(distance, null);
        IReadOnlyCollection<EnvironmentBase> routeCollection = new Collection<EnvironmentBase>
            { nebulaeOfIncreasedDensity };
        var route = new Route(routeCollection);
        RouteResult routeResult;

        // Act
        routeResult = route.Pass(pleasureShuttle);

        // Assert
        Assert.IsNotType<RouteResult.Success>(routeResult);
    }

    [Theory]
    [InlineData(400)]
    public void CheckRouteResultForAugurOnNebulaeOfIncreasedDensityFailed(double distance)
    {
        // Arrange
        ShipBase augur = new Augur();
        EnvironmentBase nebulaeOfIncreasedDensity = new NebulaeOfIncreasedDensity(distance, null);
        IReadOnlyCollection<EnvironmentBase> routeCollection = new Collection<EnvironmentBase>
            { nebulaeOfIncreasedDensity };
        var route = new Route(routeCollection);
        RouteResult routeResult;

        // Act
        routeResult = route.Pass(augur);

        // Assert
        Assert.IsNotType<RouteResult.Success>(routeResult);
    }

    [Theory]
    [InlineData(200)]
    public void CheckRouteResultForVaklasWithoutPhotonDeflectorsOnNebulaeOfIncreasedDensityWithAntimatterFlashFailed(
        double distance)
    {
        // Arrange
        ShipBase vaklas = new Vaklas(false);
        ObstacleBase antimatterFlash = new AntimatterFlash();
        IReadOnlyCollection<ObstacleBase> obstacles = new Collection<ObstacleBase> { antimatterFlash };
        EnvironmentBase nebulaeOfIncreasedDensity = new NebulaeOfIncreasedDensity(distance, obstacles);
        IReadOnlyCollection<EnvironmentBase> routeCollection = new Collection<EnvironmentBase>
            { nebulaeOfIncreasedDensity };
        var route = new Route(routeCollection);
        RouteResult routeResult;

        // Act
        routeResult = route.Pass(vaklas);

        // Assert
        Assert.IsType<RouteResult.CrewDead>(routeResult);
    }

    [Theory]
    [InlineData(200)]
    public void CheckRouteResultForVaklasWithPhotonDeflectorsOnNebulaeOfIncreasedDensityWithAntimatterFlashFailed(
        double distance)
    {
        // Arrange
        ShipBase vaklas = new Vaklas(true);
        ObstacleBase antimatterFlash = new AntimatterFlash();
        IReadOnlyCollection<ObstacleBase> obstacles = new Collection<ObstacleBase> { antimatterFlash };
        EnvironmentBase nebulaeOfIncreasedDensity = new NebulaeOfIncreasedDensity(distance, obstacles);
        IReadOnlyCollection<EnvironmentBase> routeCollection = new Collection<EnvironmentBase>
            { nebulaeOfIncreasedDensity };
        var route = new Route(routeCollection);
        RouteResult routeResult;

        // Act
        routeResult = route.Pass(vaklas);

        // Assert
        Assert.IsType<RouteResult.Success>(routeResult);
    }

    [Theory]
    [InlineData(200)]
    public void CheckRouteResultForVaklasOnNebulaeOfNitrineParticleWithSpaceWhaleFailed(
        double distance)
    {
        // Arrange
        ShipBase vaklas = new Vaklas();
        ObstacleBase spaceWhales = new SpaceWhales();
        IReadOnlyCollection<ObstacleBase> obstacles = new Collection<ObstacleBase> { spaceWhales };
        EnvironmentBase nebulaeOfNitrineParticle = new NebulaeOfNitrineParticle(distance, obstacles);
        IReadOnlyCollection<EnvironmentBase> routeCollection = new Collection<EnvironmentBase>
            { nebulaeOfNitrineParticle };
        var route = new Route(routeCollection);
        RouteResult routeResult;

        // Act
        routeResult = route.Pass(vaklas);

        // Assert
        Assert.IsType<RouteResult.ShipDead>(routeResult);
    }

    [Theory]
    [InlineData(200)]
    public void CheckRouteResultForAugurOnNebulaeOfNitrineParticleWithSpaceWhaleSuccess(
        double distance)
    {
        // Arrange
        ShipBase augur = new Augur();
        ObstacleBase spaceWhales = new SpaceWhales();
        IReadOnlyCollection<ObstacleBase> obstacles = new Collection<ObstacleBase> { spaceWhales };
        EnvironmentBase nebulaeOfNitrineParticle = new NebulaeOfNitrineParticle(distance, obstacles);
        IReadOnlyCollection<EnvironmentBase> routeCollection = new Collection<EnvironmentBase>
            { nebulaeOfNitrineParticle };
        var route = new Route(routeCollection);
        RouteResult routeResult;

        // Act
        routeResult = route.Pass(augur);

        // Assert
        Assert.IsType<RouteResult.Success>(routeResult);
        Assert.Equal(0, augur.Deflector.HitPoints);
    }

    [Theory]
    [InlineData(200)]
    public void CheckRouteResultForMeridianOnNebulaeOfNitrineParticleWithSpaceWhaleSuccess(
        double distance)
    {
        // Arrange
        ShipBase meridian = new Meridian();
        ObstacleBase spaceWhales = new SpaceWhales();
        IReadOnlyCollection<ObstacleBase> obstacles = new Collection<ObstacleBase> { spaceWhales };
        EnvironmentBase nebulaeOfNitrineParticle = new NebulaeOfNitrineParticle(distance, obstacles);
        IReadOnlyCollection<EnvironmentBase> routeCollection = new Collection<EnvironmentBase>
            { nebulaeOfNitrineParticle };
        var route = new Route(routeCollection);
        RouteResult routeResult;
        int defaultMeridianDeflectorHitPoints = meridian.Deflector.HitPoints;

        // Act
        routeResult = route.Pass(meridian);

        // Assert
        Assert.IsType<RouteResult.Success>(routeResult);
        Assert.Equal(defaultMeridianDeflectorHitPoints, meridian.Deflector.HitPoints);
    }

    [Theory]
    [InlineData(100)]
    public void ComparePleasureShuttleAndVaklasOnRegularSpacePleasureShuttle(double distance)
    {
        // Arrange
        ShipBase pleasureShuttle = new PleasureShuttle();
        ShipBase vaklas = new Vaklas();
        IReadOnlyCollection<ShipBase> shipsCollection = new Collection<ShipBase>
            { pleasureShuttle, vaklas };
        EnvironmentBase regularSpace = new RegularSpace(distance, null);
        IReadOnlyCollection<EnvironmentBase> routeCollection = new Collection<EnvironmentBase>
            { regularSpace };
        var route = new Route(routeCollection);
        var optimalShipFinder = new OptimalShipFinder();
        ShipBase? optimalShip;

        // Act
        optimalShip = optimalShipFinder.Find(shipsCollection, route);

        // Assert
        Assert.IsType<PleasureShuttle>(optimalShip);
    }

    [Theory]
    [InlineData(200)]
    public void CompareAugurAndStellaOnNebulaeOfIncreasedDensityStella(double distance)
    {
        // Arrange
        ShipBase augur = new Augur();
        ShipBase stella = new Stella();
        IReadOnlyCollection<ShipBase> shipsCollection = new Collection<ShipBase>
            { augur, stella };
        EnvironmentBase nebulaeOfIncreasedDensity = new NebulaeOfIncreasedDensity(distance, null);
        IReadOnlyCollection<EnvironmentBase> routeCollection = new Collection<EnvironmentBase>
            { nebulaeOfIncreasedDensity };
        var route = new Route(routeCollection);
        var optimalShipFinder = new OptimalShipFinder();
        ShipBase? optimalShip;

        // Act
        optimalShip = optimalShipFinder.Find(shipsCollection, route);

        // Assert
        Assert.IsType<Stella>(optimalShip);
    }

    [Theory]
    [InlineData(200)]
    public void ComparePleasureShuttleAndVaklasOnNebulaeOfNitrineParticleVaklas(double distance)
    {
        // Arrange
        ShipBase pleasureShuttle = new PleasureShuttle();
        ShipBase vaklas = new Vaklas();
        IReadOnlyCollection<ShipBase> shipsCollection = new Collection<ShipBase>
            { pleasureShuttle, vaklas };
        EnvironmentBase nebulaeOfNitrineParticle = new NebulaeOfNitrineParticle(distance, null);
        IReadOnlyCollection<EnvironmentBase> routeCollection = new Collection<EnvironmentBase>
            { nebulaeOfNitrineParticle };
        var route = new Route(routeCollection);
        var optimalShipFinder = new OptimalShipFinder();
        ShipBase? optimalShip;

        // Act
        optimalShip = optimalShipFinder.Find(shipsCollection, route);

        // Assert
        Assert.IsType<Vaklas>(optimalShip);
    }

    [Theory]
    [InlineData(200)]
    public void CompareVaklasAndMeridianOnRegularSpaceAndNebulaeOfNitrineParticleWithSpaceWhalesMeridian(
        double distance)
    {
        // Arrange
        ShipBase vaklas = new Vaklas();
        ShipBase meridian = new Meridian();
        IReadOnlyCollection<ShipBase> shipsCollection = new Collection<ShipBase>
            { vaklas, meridian };
        EnvironmentBase regularSpace = new RegularSpace(distance, null);
        IReadOnlyCollection<ObstacleBase> obstacles = new Collection<ObstacleBase> { new SpaceWhales() };
        EnvironmentBase nebulaeOfNitrineParticle = new NebulaeOfNitrineParticle(distance, obstacles);
        IReadOnlyCollection<EnvironmentBase> routeCollection = new Collection<EnvironmentBase>
            { regularSpace, nebulaeOfNitrineParticle };
        var route = new Route(routeCollection);
        var optimalShipFinder = new OptimalShipFinder();
        ShipBase? optimalShip;

        // Act
        optimalShip = optimalShipFinder.Find(shipsCollection, route);

        // Assert
        Assert.IsType<Meridian>(optimalShip);
    }
}