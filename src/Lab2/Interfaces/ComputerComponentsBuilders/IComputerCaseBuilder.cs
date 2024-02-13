using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;

public interface IComputerCaseBuilder
{
    IComputerCaseBuilder WithName(string name);

    IComputerCaseBuilder WithMaxGraphicsCardLength(int maxGraphicsCardLenght);

    IComputerCaseBuilder WithMaxGraphicsCardWidth(int maxGraphicsCardWidth);

    IComputerCaseBuilder AddSupportedMotherboardFormFactor(MotherboardFormFactor motherboardFormFactor);

    IComputerCaseBuilder WithDimensions(Dimensions dimensions);

    void Reset();

    ComputerCase Build();
}