using Godot;

public partial class Main : Node
{
    [Export]
    Camera3D camera3D;
    public override void _Ready()
    {
        RayCaster rayCaster = GD.Load<PackedScene>("res://RayCaster.tscn").Instantiate<RayCaster>();
        rayCaster.Setup(camera3D);
        AddChild(rayCaster);
    }
}