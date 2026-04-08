using Godot;
using System;

[Tool]
public partial class TrackingCamera : Camera3D
{
    [Export] Node3D TrackNode = null;

    Node3D Parent = null;
    [Export] Vector3 Offset = Vector3.Zero;

    public override void _EnterTree()
    {
        Parent = GetParent<Node3D>();
        base._EnterTree();
    }

    public override void _Process(double delta)
    {
        if(TrackNode != null && Parent != null)
        {
            Position = TrackNode.GlobalPosition - GetParent<Node3D>().GlobalPosition+Offset;
        }
        base._Process(delta);
    }
}
