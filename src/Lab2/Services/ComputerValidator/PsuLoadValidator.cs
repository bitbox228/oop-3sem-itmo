using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerValidator;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class PsuLoadValidator : IComputerValidator
{
    private const int OverstatementPercentage = 25;
    private const string Comment = "Not enough power in PSU.";

    public ComponentsValidationResult Validate(Pc pc)
    {
        pc = pc ?? throw new ArgumentNullException(nameof(pc));

        int overallPowerConsumption = 0;

        overallPowerConsumption += pc.Cpu.PowerConsumption;

        foreach (Ram ram in pc.RamSticks)
        {
            overallPowerConsumption += ram.PowerConsumption;
        }

        foreach (Hdd hdd in pc.HddDisks)
        {
            overallPowerConsumption += hdd.PowerConsumption;
        }

        foreach (Ssd ssd in pc.SsdDisks)
        {
            overallPowerConsumption += ssd.PowerConsumption;
        }

        if (pc.GraphicsCard is not null)
        {
            overallPowerConsumption += pc.GraphicsCard.PowerConsumption;
        }

        if (pc.WifiAdapter is not null)
        {
            overallPowerConsumption += pc.WifiAdapter.PowerConsumption;
        }

        if (overallPowerConsumption > pc.Psu.PeakLoad)
        {
            return new ComponentsValidationResult.IncompatibleComputerComponents(Comment);
        }

        if (overallPowerConsumption > pc.Psu.PeakLoad - (overallPowerConsumption / 100 * OverstatementPercentage))
        {
            return new ComponentsValidationResult.PowerConsumptionWarning();
        }

        return new ComponentsValidationResult.Success();
    }
}