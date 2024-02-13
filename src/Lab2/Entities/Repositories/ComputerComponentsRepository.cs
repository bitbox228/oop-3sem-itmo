using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;

public class ComputerComponentsRepository
{
    public ComputerComponentsRepository()
    {
        MotherboardRepository = new ComponentRepository<Motherboard>();
        CpuRepository = new ComponentRepository<Cpu>();
        HeatsinkRepository = new ComponentRepository<Heatsink>();
        RamRepository = new ComponentRepository<Ram>();
        GraphicsCardRepository = new ComponentRepository<GraphicsCard>();
        SsdRepository = new ComponentRepository<Ssd>();
        HddRepository = new ComponentRepository<Hdd>();
        ComputerCaseRepository = new ComponentRepository<ComputerCase>();
        PsuRepository = new ComponentRepository<Psu>();
        WifiAdapterRepository = new ComponentRepository<WifiAdapter>();
    }

    public ComponentRepository<Motherboard> MotherboardRepository { get; }
    public ComponentRepository<Cpu> CpuRepository { get; }
    public ComponentRepository<Heatsink> HeatsinkRepository { get; }
    public ComponentRepository<Ram> RamRepository { get; }
    public ComponentRepository<GraphicsCard> GraphicsCardRepository { get; }
    public ComponentRepository<Ssd> SsdRepository { get; }
    public ComponentRepository<Hdd> HddRepository { get; }
    public ComponentRepository<ComputerCase> ComputerCaseRepository { get; }
    public ComponentRepository<Psu> PsuRepository { get; }
    public ComponentRepository<WifiAdapter> WifiAdapterRepository { get; }
}