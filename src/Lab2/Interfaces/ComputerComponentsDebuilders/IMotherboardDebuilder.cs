using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsDebuilders;

public interface IMotherboardDebuilder
{
    IMotherboardBuilder Debuild(IMotherboardBuilder motherboardBuilder);
}