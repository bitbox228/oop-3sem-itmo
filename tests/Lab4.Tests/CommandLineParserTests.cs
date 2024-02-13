using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CommandLineParserTests
{
    [Fact]
    public void SuccessConnectParseTest()
    {
        // Arrange
        var parser = new CommandLineParser();
        const string line = "connect /home/user -m local";

        // Act
        ParserResult result = parser.Parse(line);

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        Assert.IsType<ConnectCommand>(((ParserResult.Success)result).Command);
    }

    [Fact]
    public void FailedNoArgumentConnectParseTest()
    {
        // Arrange
        var parser = new CommandLineParser();
        const string line = "connect -m local";

        // Act
        ParserResult result = parser.Parse(line);

        // Assert
        Assert.IsType<ParserResult.Failed>(result);
    }

    [Fact]
    public void FailedNoFlagConnectParseTest()
    {
        // Arrange
        var parser = new CommandLineParser();
        const string line = "connect /home/user";

        // Act
        ParserResult result = parser.Parse(line);

        // Assert
        Assert.IsType<ParserResult.Failed>(result);
    }

    [Fact]
    public void SuccessDisconnectParseTest()
    {
        // Arrange
        var parser = new CommandLineParser();
        const string line = "disconnect";

        // Act
        ParserResult result = parser.Parse(line);

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        Assert.IsType<DisconnectCommand>(((ParserResult.Success)result).Command);
    }

    [Fact]
    public void SuccessFileCopyParseTest()
    {
        // Arrange
        var parser = new CommandLineParser();
        const string line = "file copy filename path";

        // Act
        ParserResult result = parser.Parse(line);

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        Assert.IsType<FileCopyCommand>(((ParserResult.Success)result).Command);
    }

    [Fact]
    public void FailedFileCopyParseTest()
    {
        // Arrange
        var parser = new CommandLineParser();
        const string line = "file copy filename";

        // Act
        ParserResult result = parser.Parse(line);

        // Assert
        Assert.IsType<ParserResult.Failed>(result);
    }

    [Fact]
    public void SuccessFileDeleteParseTest()
    {
        // Arrange
        var parser = new CommandLineParser();
        const string line = "file delete path";

        // Act
        ParserResult result = parser.Parse(line);

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        Assert.IsType<FileDeleteCommand>(((ParserResult.Success)result).Command);
    }

    [Fact]
    public void SuccessFileMoveParseTest()
    {
        // Arrange
        var parser = new CommandLineParser();
        const string line = "file move filename path";

        // Act
        ParserResult result = parser.Parse(line);

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        Assert.IsType<FileMoveCommand>(((ParserResult.Success)result).Command);
    }

    [Fact]
    public void SuccessFileRenameParseTest()
    {
        // Arrange
        var parser = new CommandLineParser();
        const string line = "file rename filename newname";

        // Act
        ParserResult result = parser.Parse(line);

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        Assert.IsType<FileRenameCommand>(((ParserResult.Success)result).Command);
    }

    [Fact]
    public void SuccessFileShowParseTest()
    {
        // Arrange
        var parser = new CommandLineParser();
        const string line = "file show filename -m console";

        // Act
        ParserResult result = parser.Parse(line);

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        Assert.IsType<FileShowCommand>(((ParserResult.Success)result).Command);
    }

    [Fact]
    public void SuccessTreeGotoParseTest()
    {
        // Arrange
        var parser = new CommandLineParser();
        const string line = "tree goto path";

        // Act
        ParserResult result = parser.Parse(line);

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        Assert.IsType<TreeGotoCommand>(((ParserResult.Success)result).Command);
    }

    [Fact]
    public void SuccessTreeListParseTest()
    {
        // Arrange
        var parser = new CommandLineParser();
        const string line = "tree list -fi icon -d 100";

        // Act
        ParserResult result = parser.Parse(line);

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        Assert.IsType<TreeListCommand>(((ParserResult.Success)result).Command);
    }

    [Fact]
    public void FailedUnexistentCommandParseTest()
    {
        // Arrange
        var parser = new CommandLineParser();
        const string line = "tree delete path";

        // Act
        ParserResult result = parser.Parse(line);

        // Assert
        Assert.IsType<ParserResult.Failed>(result);
    }
}