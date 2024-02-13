using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.DisplayDriver;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class DisplayDriver : IDisplayDriver
{
    public DisplayDriver()
    {
        Text = string.Empty;
        Color = Color.Empty;
    }

    public string Text { get; set; }
    public Color Color { get; set; }
}