using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces.DisplayDriver;

public interface IDisplayDriver
{
    string Text { get; set; }

    Color Color { get; set; }
}