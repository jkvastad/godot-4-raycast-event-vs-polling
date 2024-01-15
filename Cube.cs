using Godot;
using System;

public partial class Cube : Area3D
{
    public const int CUBE_COLLISION_LAYER = 0b00000000_00000000_00000000_00000100;

    public override void _Ready()
    {
        CollisionLayer = CUBE_COLLISION_LAYER;
    }

    public override void _InputEvent(Camera3D camera, InputEvent @event, Vector3 position, Vector3 normal, int shapeIdx)
    {
        if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed && mouseButton.ButtonIndex == MouseButton.Left)
        {
            GD.Print($"{GetPath()} was pressed!");
        }
    }
}
