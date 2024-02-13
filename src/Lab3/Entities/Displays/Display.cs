using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.DisplayDriver;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class Display : IDisplay
{
    private readonly IDisplayDriver _displayDriver;
    private readonly ILogger _logger;

    public Display(IDisplayDriver displayDriver, ILogger logger)
    {
        _displayDriver = displayDriver;
        _logger = logger;
    }

    public static IDisplayDisplayDriverSelector Builder => new DisplayBuilder();

    public void SaveMessage(string message)
    {
        _displayDriver.Text = message;
    }

    public void ChangeColor(Color color)
    {
        _displayDriver.Color = color;
    }

    public void DisplayMessage()
    {
        string coloredText = Crayon.Output
            .Rgb(_displayDriver.Color.R, _displayDriver.Color.G, _displayDriver.Color.B)
            .Text(_displayDriver.Text);

        _logger.Output(coloredText);

        _displayDriver.Text = string.Empty;
    }

    private class DisplayBuilder :
        IDisplayBuilder,
        IDisplayDisplayDriverSelector,
        IDisplayLoggerSelector
    {
        private IDisplayDriver? _displayDriver;
        private ILogger? _logger;

        public DisplayBuilder()
        {
            _displayDriver = null;
            _logger = null;
        }

        public IDisplayLoggerSelector WithDisplayDriver(IDisplayDriver displayDriver)
        {
            _displayDriver = displayDriver;
            return this;
        }

        public IDisplayBuilder WithLogger(ILogger logger)
        {
            _logger = logger;
            return this;
        }

        public IDisplay Build()
        {
            return new Display(
                _displayDriver ?? throw new ArgumentNullException(nameof(_displayDriver)),
                _logger ?? throw new ArgumentNullException(nameof(_logger)));
        }
    }
}