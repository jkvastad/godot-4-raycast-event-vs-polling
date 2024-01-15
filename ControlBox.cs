using Godot;
using System;

public partial class ControlBox : PanelContainer
{

    public override void _GuiInput(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed && mouseButton.ButtonIndex == MouseButton.Left)
        {
            GD.Print($"{GetPath()} was pressed!");
        }
    }
}
