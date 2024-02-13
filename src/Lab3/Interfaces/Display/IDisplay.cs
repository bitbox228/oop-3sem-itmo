using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Display;

public interface IDisplay
{
    void SaveMessage(string message);

    void ChangeColor(Color color);

    void DisplayMessage();
}