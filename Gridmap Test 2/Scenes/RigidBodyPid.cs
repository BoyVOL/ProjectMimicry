using Godot;
using System;

public partial class RigidBodyPid : Node
{
    [Export] RigidBody3D ControlledNode = null;

    public Vector3 DesiredVector = Vector3.Zero;

	[Export]Vector3 MovePID = new Vector3(0.01F,0.01F,0.01F);

	[Export]float MoveImpulseClamp = 100F;

	V3PID MovePIDControl = new V3PID();

    

	public override void _PhysicsProcess(double delta)
	{
        if (ControlledNode != null)
        {
            MovePIDControl.P = MovePID.X;
            MovePIDControl.I = MovePID.Y;
            MovePIDControl.D = MovePID.Z;
            Vector3 Error = DesiredVector - ControlledNode.LinearVelocity;
            Vector3 New = MovePIDControl.newVector(Error,(float)delta);
            ControlledNode.ApplyImpulse(new Vector3(New.X, 0, New.Z));
        }
		base._PhysicsProcess(delta);
	}
}
