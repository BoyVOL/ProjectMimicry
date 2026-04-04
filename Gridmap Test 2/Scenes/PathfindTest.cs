using Godot;
using System;

public partial class PathfindTest : RigidBody3D
{
    [Export] Node3D PathfindTarget = null;
    [Export] NavigationAgent3D Navigator = null;
    Vector3 NextPathPoint = Vector3.Zero;

    public override void _PhysicsProcess(double delta)
    {
        if(PathfindTarget != null && Navigator != null)
        {
            Navigator.TargetPosition = PathfindTarget.GlobalPosition;
            NextPathPoint = Navigator.GetNextPathPosition();
            GD.Print(NextPathPoint);
        }
        base._PhysicsProcess(delta);
    }

}
