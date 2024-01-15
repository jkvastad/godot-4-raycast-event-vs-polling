using Godot;
using System;

public partial class RayCaster : Node
{
    bool IsLeftMouseAlreadyPressed = false;
    Camera3D _camera3D;

    public void Setup(Camera3D camera3D)
    {
        _camera3D = camera3D;
    }
    public override void _PhysicsProcess(double delta)
    {
        if (Input.IsMouseButtonPressed(MouseButton.Left) && !IsLeftMouseAlreadyPressed)
        {
            IsLeftMouseAlreadyPressed = true;

            Vector2 mousePosition = GetViewport().GetMousePosition();
            Cast2DRay(mousePosition);
            Cast3DRay(mousePosition);
        }
        if (!Input.IsMouseButtonPressed(MouseButton.Left))
        {
            IsLeftMouseAlreadyPressed = false;
        }
    }

    private void Cast2DRay(Vector2 mousePosition)
    {
        GD.Print($"Casting ray in 2D from {Vector2.Zero} to {mousePosition}");

        PhysicsDirectSpaceState2D spaceState = GetViewport().World2D.DirectSpaceState;
        PhysicsPointQueryParameters2D query = new PhysicsPointQueryParameters2D()
        {
            Position = mousePosition,
            CollideWithAreas = true,
            CollisionMask = Rectangle.RECTANGLE_COLLISION_LAYER
        };

        var result = spaceState.IntersectPoint(query);

        GD.Print($"Hit {result}");
    }

    private void Cast3DRay(Vector2 mousePosition)
    {
        Vector3 from = _camera3D.ProjectRayOrigin(mousePosition);
        Vector3 to = from + _camera3D.ProjectRayNormal(mousePosition) * _camera3D.Far;

        GD.Print($"Casting ray in 3D from {from} to {to}");

        PhysicsDirectSpaceState3D spaceState = GetViewport().World3D.DirectSpaceState;
        PhysicsRayQueryParameters3D query = new PhysicsRayQueryParameters3D()
        {
            From = from,
            To = to,
            CollideWithAreas = true,
            CollisionMask = Cube.CUBE_COLLISION_LAYER
        };
        Godot.Collections.Dictionary result = spaceState.IntersectRay(query);

        GD.Print($"Hit {result}");

        if (result.Count > 0 && result["collider"] is Variant variant && variant.Obj is Cube cube)
        {
            GD.Print($"Object is {variant}");
            GD.Print($"It's a {cube.GetPath()}");
        }
    }
}