using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsDebuilders;

public interface IGraphicsCardDebuilder
{
    IGraphicsCardBuilder Debuild(IGraphicsCardBuilder graphicsCardBuilder);
}