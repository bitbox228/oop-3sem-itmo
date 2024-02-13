using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.PcBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;

public class Pc : IPcDebuilder
{
    public Pc(
        Motherboard motherboard,
        Cpu cpu,
        Heatsink heatsink,
        IEnumerable<Ram> ramSticks,
        GraphicsCard? graphicsCard,
        IEnumerable<Ssd> ssdDisks,
        IEnumerable<Hdd> hddDisks,
        ComputerCase computerCase,
        Psu psu,
        WifiAdapter? wifiAdapter)
    {
        Motherboard = motherboard;
        Cpu = cpu;
        Heatsink = heatsink;
        RamSticks = ramSticks.ToArray();
        GraphicsCard = graphicsCard;
        SsdDisks = ssdDisks.ToArray();
        HddDisks = hddDisks.ToArray();
        ComputerCase = computerCase;
        Psu = psu;
        WifiAdapter = wifiAdapter;
    }

    public Motherboard Motherboard { get; }
    public Cpu Cpu { get; }
    public Heatsink Heatsink { get; }
    public IReadOnlyCollection<Ram> RamSticks { get; }
    public GraphicsCard? GraphicsCard { get; }
    public IReadOnlyCollection<Ssd> SsdDisks { get; }
    public IReadOnlyCollection<Hdd> HddDisks { get; }
    public ComputerCase ComputerCase { get; }
    public Psu Psu { get; }
    public WifiAdapter? WifiAdapter { get; }

    public IPcBuilder Debuild(IPcBuilder pcBuilder)
    {
        pcBuilder = pcBuilder ?? throw new ArgumentNullException(nameof(pcBuilder));

        pcBuilder.Reset();

        pcBuilder.WithMotherBoard(Motherboard);
        pcBuilder.WithCpu(Cpu);
        pcBuilder.WithHeatsink(Heatsink);
        pcBuilder.WithComputerCase(ComputerCase);
        pcBuilder.WithPsu(Psu);

        foreach (Ram ram in RamSticks)
        {
            pcBuilder.AddRam(ram);
        }

        foreach (Ssd ssd in SsdDisks)
        {
            pcBuilder.AddSsd(ssd);
        }

        foreach (Hdd hdd in HddDisks)
        {
            pcBuilder.AddHdd(hdd);
        }

        if (GraphicsCard is not null) pcBuilder.WithGraphicsCard(GraphicsCard);
        if (WifiAdapter is not null) pcBuilder.WithWifiAdapter(WifiAdapter);

        return pcBuilder;
    }
}