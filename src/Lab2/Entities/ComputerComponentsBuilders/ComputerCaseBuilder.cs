using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponentsBuilders;

public class ComputerCaseBuilder : IComputerCaseBuilder
{
    private string? _name;
    private int _maxGraphicsCardLength;
    private int _maxGraphicsCardWidth;
    private List<MotherboardFormFactor> _supportedMotherboardFormFactors;
    private Dimensions? _dimensions;

    public ComputerCaseBuilder()
    {
        _supportedMotherboardFormFactors = new List<MotherboardFormFactor>();
    }

    public IComputerCaseBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IComputerCaseBuilder WithMaxGraphicsCardLength(int maxGraphicsCardLenght)
    {
        _maxGraphicsCardLength = maxGraphicsCardLenght;
        return this;
    }

    public IComputerCaseBuilder WithMaxGraphicsCardWidth(int maxGraphicsCardWidth)
    {
        _maxGraphicsCardWidth = maxGraphicsCardWidth;
        return this;
    }

    public IComputerCaseBuilder AddSupportedMotherboardFormFactor(MotherboardFormFactor motherboardFormFactor)
    {
        _supportedMotherboardFormFactors.Add(motherboardFormFactor);
        return this;
    }

    public IComputerCaseBuilder WithDimensions(Dimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public void Reset()
    {
        _name = null;
        _maxGraphicsCardLength = 0;
        _maxGraphicsCardWidth = 0;
        _supportedMotherboardFormFactors.Clear();
        _dimensions = null;
    }

    public ComputerCase Build()
    {
        return new ComputerCase(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _maxGraphicsCardLength,
            _maxGraphicsCardWidth,
            _supportedMotherboardFormFactors,
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)));
    }
}