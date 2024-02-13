using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerComponentsBuilders;

public interface IRamBuilder
{
    IRamBuilder WithName(string name);

    IRamBuilder WithMemorySize(int memorySize);

    IRamBuilder AddSupportedJedec(Jedec jedec);

    IRamBuilder AddSupportedVoltage(int voltage);

    IRamBuilder AddXmpProfile(XmpProfile xmpProfile);

    IRamBuilder WithRamFormFactor(RamFormFactor ramFormFactor);

    IRamBuilder WithDdrStandart(DdrStandard ddrStandard);

    IRamBuilder WithPowerConsumption(int powerConsumption);

    void Reset();

    Ram Build();
}