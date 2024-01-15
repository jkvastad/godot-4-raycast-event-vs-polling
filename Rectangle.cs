using Godot;
using System;

public partial class Rectangle : Area2D
{
    public const int RECTANGLE_COLLISION_LAYER = 0b00000000_00000000_00000000_00000010;    

    public override void _Ready()
    {
        CollisionLayer = RECTANGLE_COLLISION_LAYER;
    }

    public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
    {
        if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed && mouseButton.ButtonIndex == MouseButton.Left)
        {
            GD.Print($"{GetPath()} was pressed!");
        }
    }
}
