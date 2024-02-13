using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsDebuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

public class GraphicsCard : ComputerComponentBase, IEquatable<GraphicsCard>, IGraphicsCardDebuilder
{
    public GraphicsCard(
        string name,
        int videoMemorySize,
        int pcieVersion,
        int chipFrequency,
        int powerConsumption,
        int length,
        int width)
        : base(name)
    {
        if (videoMemorySize < 0) throw new NegativeValueException(nameof(videoMemorySize));
        if (pcieVersion < 0) throw new NegativeValueException(nameof(pcieVersion));
        if (chipFrequency < 0) throw new NegativeValueException(nameof(chipFrequency));
        if (powerConsumption < 0) throw new NegativeValueException(nameof(powerConsumption));
        if (length < 0) throw new NegativeValueException(nameof(length));
        if (width < 0) throw new NegativeValueException(nameof(width));

        VideoMemorySize = videoMemorySize;
        PcieVersion = pcieVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
        Length = length;
        Width = width;
    }

    public int Length { get; }
    public int Width { get; }
    public int VideoMemorySize { get; }
    public int PcieVersion { get; }
    public int ChipFrequency { get; }
    public int PowerConsumption { get; }

    public bool Equals(GraphicsCard? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name.Equals(other.Name, StringComparison.Ordinal);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return GetType() == obj.GetType() && Equals((GraphicsCard)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode(StringComparison.Ordinal);
    }

    public IGraphicsCardBuilder Debuild(IGraphicsCardBuilder graphicsCardBuilder)
    {
        graphicsCardBuilder = graphicsCardBuilder ?? throw new ArgumentNullException(nameof(graphicsCardBuilder));

        graphicsCardBuilder.Reset();

        graphicsCardBuilder.WithName(Name);
        graphicsCardBuilder.WithVideoMemorySize(VideoMemorySize);
        graphicsCardBuilder.WithPcieVersion(PcieVersion);
        graphicsCardBuilder.WithChipFrequency(ChipFrequency);
        graphicsCardBuilder.WithPowerConsumption(PowerConsumption);
        graphicsCardBuilder.WithLength(Length);
        graphicsCardBuilder.WithWidth(Width);

        return graphicsCardBuilder;
    }
}