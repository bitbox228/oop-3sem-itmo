using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.ComputerValidator;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.PcBuilder;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.RepositoryInitializers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ComputerTests
{
    private ComputerComponentsRepository _repository;
    private List<IComputerValidator> _validators;
    private Specification _specification;

    public ComputerTests()
    {
        var computerRepositoryInitializer = new ComputerRepositoryInitializer();
        computerRepositoryInitializer.Add(new CpuRepositoryInitializer());
        computerRepositoryInitializer.Add(new MotherboardRepositoryInitializer());
        computerRepositoryInitializer.Add(new HeatsinkRepositoryInitializer());
        computerRepositoryInitializer.Add(new RamRepositoryInitializer());
        computerRepositoryInitializer.Add(new GraphicsCardInitializer());
        computerRepositoryInitializer.Add(new SsdRepositoryInitializer());
        computerRepositoryInitializer.Add(new HddRepositoryInitializer());
        computerRepositoryInitializer.Add(new ComputerCaseRepositoryInitializer());
        computerRepositoryInitializer.Add(new PsuRepositoryInitializer());
        computerRepositoryInitializer.Add(new WifiAdapterRepositoryInitializer());

        _repository = new ComputerComponentsRepository();
        computerRepositoryInitializer.Initialize(_repository);

        _validators = new List<IComputerValidator>()
        {
            new RamSticksValidator(),
            new GraphicsCardToCpuValidator(),
            new DisksValidator(),
            new CpuToBiosValidator(),
            new CpuToHeatsinkValidator(),
            new CpuToMotherboardValidator(),
            new GraphicsCardToComputerCaseValidator(),
            new MotherboardPortsValidation(),
            new MotherboardToComputerCaseValidator(),
            new PsuLoadValidator(),
            new RamToMotherboardValidator(),
            new WifiAdapterToMotherboardValidator(),
        };

        _specification = new Specification();
        _specification.RamStickNames.Add("AMD Radeon R9 Gamer Series");
        _specification.RamStickNames.Add("AMD Radeon R9 Gamer Series");
        _specification.SsdDiskNames.Add("MSI SPATIUM M450");
        _specification.HddDiskNames.Add("Toshiba P300");
        _specification.ComputerCaseName = "Cougar MX330-G";
        _specification.PsuName = "MSI MAG A550BN";
        _specification.WifiAdapterName = "TP-LINK Archer T2E";
    }

    [Fact]
    public void SuccessfulPcBuildTest()
    {
        // Arrange
        IPcBuilder pcBuilder = new PcBuilder(new OverallComputerValidator(_validators));
        PcBuildResult result;
        var pcDirectorBuilder = new PcDirectorBuilder();

        _specification.MotherboardName = "MSI MAG B550 TOMAHAWK";
        _specification.CpuName = "AMD Ryzen 7 5700X OEM";
        _specification.HeatsinkName = "DEEPCOOL GAMMAXX 300 FURY";
        _specification.GraphicsCardName = "MSI GeForce RTX 4060 GAMING X";

        // Act
        pcBuilder = pcDirectorBuilder.Direct(pcBuilder, _specification, _repository);
        result = pcBuilder.Build();

        // Assert
        Assert.IsType<PcBuildResult.Success>(result);
    }

    [Fact]
    public void PowerConsumptionWarningBuildTest()
    {
        // Arrange
        IPcBuilder pcBuilder = new PcBuilder(new OverallComputerValidator(_validators));
        PcBuildResult result;
        var pcDirectorBuilder = new PcDirectorBuilder();

        _specification.MotherboardName = "MSI MAG B550 TOMAHAWK";
        _specification.CpuName = "AMD Ryzen 7 5700X OEM";
        _specification.HeatsinkName = "DEEPCOOL GAMMAXX 300 FURY";
        _specification.GraphicsCardName = "NVIDIA SUPER MEGA GTX 8090 TI ULTRA MEGA SUPER";

        // Act
        pcBuilder = pcDirectorBuilder.Direct(pcBuilder, _specification, _repository);
        result = pcBuilder.Build();

        // Assert
        Assert.IsType<PcBuildResult.PowerConsumptionWarning>(result);
    }

    [Fact]
    public void WarrantyDisclaimerBuildTest()
    {
        // Arrange
        IPcBuilder pcBuilder = new PcBuilder(new OverallComputerValidator(_validators));
        PcBuildResult result;
        var pcDirectorBuilder = new PcDirectorBuilder();

        _specification.MotherboardName = "MSI MAG B550 TOMAHAWK";
        _specification.CpuName = "AMD Ryzen 7 5700X OEM";
        _specification.HeatsinkName = "VERY WEAK HEATSINK";
        _specification.GraphicsCardName = "MSI GeForce RTX 4060 GAMING X";

        // Act
        pcBuilder = pcDirectorBuilder.Direct(pcBuilder, _specification, _repository);
        result = pcBuilder.Build();

        // Assert
        Assert.IsType<PcBuildResult.WarrantyDisclaimer>(result);
    }

    [Fact]
    public void IncompatibleCpuAndHeatsinkBuild()
    {
        // Arrange
        IPcBuilder pcBuilder = new PcBuilder(new OverallComputerValidator(_validators));
        PcBuildResult result;
        var pcDirectorBuilder = new PcDirectorBuilder();

        string resultComment = "Incompatible Heatsink and CPU sockets.";

        _specification.MotherboardName = "MSI MAG Z690 TOMAHAWK";
        _specification.CpuName = "Intel Core i9-13900K OEM";
        _specification.HeatsinkName = "Heatsink not for INTEL";
        _specification.GraphicsCardName = "MSI GeForce RTX 4060 GAMING X";

        // Act
        pcBuilder = pcDirectorBuilder.Direct(pcBuilder, _specification, _repository);
        result = pcBuilder.Build();

        // Assert
        Assert.IsType<PcBuildResult.IncompatibleComputerComponents>(result);
        Assert.Equal(resultComment, ((PcBuildResult.IncompatibleComputerComponents)result).Comment);
    }

    [Fact]
    public void IncompatibleCpuAndBiosBuild()
    {
        // Arrange
        IPcBuilder pcBuilder = new PcBuilder(new OverallComputerValidator(_validators));
        PcBuildResult result;
        var pcDirectorBuilder = new PcDirectorBuilder();

        string resultComment = "CPU is not supported by BIOS.";

        _specification.MotherboardName = "MSI MAG B550 TOMAHAWK";
        _specification.CpuName = "Intel Core i9-13900K OEM";
        _specification.HeatsinkName = "DEEPCOOL GAMMAX 300B";
        _specification.GraphicsCardName = "MSI GeForce RTX 4060 GAMING X";

        // Act
        pcBuilder = pcDirectorBuilder.Direct(pcBuilder, _specification, _repository);
        result = pcBuilder.Build();

        // Assert
        Assert.IsType<PcBuildResult.IncompatibleComputerComponents>(result);
        Assert.Equal(resultComment, ((PcBuildResult.IncompatibleComputerComponents)result).Comment);
    }

    [Fact]
    public void IncompatibleGraphicsCardAndComputerCaseBuild()
    {
        // Arrange
        IPcBuilder pcBuilder = new PcBuilder(new OverallComputerValidator(_validators));
        PcBuildResult result;
        var pcDirectorBuilder = new PcDirectorBuilder();

        string resultComment = "Graphics card doesn't fit in the computer case.";

        _specification.MotherboardName = "MSI MAG B550 TOMAHAWK";
        _specification.CpuName = "AMD Ryzen 7 5700X OEM";
        _specification.HeatsinkName = "DEEPCOOL GAMMAXX 300 FURY";
        _specification.GraphicsCardName = "BIG MSI GeForce RTX 4060 GAMING X";

        // Act
        pcBuilder = pcDirectorBuilder.Direct(pcBuilder, _specification, _repository);
        result = pcBuilder.Build();

        // Assert
        Assert.IsType<PcBuildResult.IncompatibleComputerComponents>(result);
        Assert.Equal(resultComment, ((PcBuildResult.IncompatibleComputerComponents)result).Comment);
    }

    [Fact]
    public void NoDisksBuild()
    {
        // Arrange
        IPcBuilder pcBuilder = new PcBuilder(new OverallComputerValidator(_validators));
        PcBuildResult result;
        var pcDirectorBuilder = new PcDirectorBuilder();

        string resultComment = "PC should contain at least one disk of any type.";

        _specification.MotherboardName = "MSI MAG B550 TOMAHAWK";
        _specification.CpuName = "AMD Ryzen 7 5700X OEM";
        _specification.HeatsinkName = "DEEPCOOL GAMMAXX 300 FURY";
        _specification.GraphicsCardName = "MSI GeForce RTX 4060 GAMING X";
        _specification.HddDiskNames.Clear();
        _specification.SsdDiskNames.Clear();

        // Act
        pcBuilder = pcDirectorBuilder.Direct(pcBuilder, _specification, _repository);
        result = pcBuilder.Build();

        // Assert
        Assert.IsType<PcBuildResult.NoMandatoryComponent>(result);
        Assert.Equal(resultComment, ((PcBuildResult.NoMandatoryComponent)result).Comment);
    }
}