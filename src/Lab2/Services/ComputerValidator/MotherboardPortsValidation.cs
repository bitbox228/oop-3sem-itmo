using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerValidator;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerComponentsAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class MotherboardPortsValidation : IComputerValidator
{
    private const string Comment = "Not enough SATA/PCI-E ports in Motherboard.";

    public ComponentsValidationResult Validate(Pc pc)
    {
        pc = pc ?? throw new ArgumentNullException(nameof(pc));

        var pciePorts = new Dictionary<int, int>();
        int sataPortsCount = pc.HddDisks.Count;

        if (pc.GraphicsCard is not null)
        {
            pciePorts.Add(pc.GraphicsCard.PcieVersion, 1);
        }

        if (pc.WifiAdapter is not null)
        {
            if (pciePorts.ContainsKey(pc.WifiAdapter.PcieVersion))
                pciePorts[pc.WifiAdapter.PcieVersion] += 1;
            else
                pciePorts.Add(pc.WifiAdapter.PcieVersion, 1);
        }

        foreach (Ssd ssd in pc.SsdDisks)
        {
            if (ssd.ConnectionType is ConnectionType.Pcie)
            {
                int pcieVersion = ((ConnectionType.Pcie)ssd.ConnectionType).PcieVersion;
                if (pciePorts.ContainsKey(pcieVersion))
                    pciePorts[pcieVersion] += 1;
                else
                    pciePorts.Add(pcieVersion, 1);
            }
            else
            {
                sataPortsCount += 1;
            }
        }

        if (sataPortsCount > pc.Motherboard.SataPortsCount)
        {
            return
                new ComponentsValidationResult.IncompatibleComputerComponents(Comment);
        }

        foreach (Pcie pciePort in pc.Motherboard.PciePorts)
        {
            if (pciePorts.ContainsKey(pciePort.PcieVersion))
            {
                int pcieVersion = pciePort.PcieVersion;
                if (pciePort.Count < pciePorts[pcieVersion])
                {
                    return
                        new ComponentsValidationResult.IncompatibleComputerComponents(Comment);
                }

                pciePorts.Remove(pcieVersion);
            }
        }

        if (pciePorts.Count > 0)
        {
            return
                new ComponentsValidationResult.IncompatibleComputerComponents(Comment);
        }

        return new ComponentsValidationResult.Success();
    }
}