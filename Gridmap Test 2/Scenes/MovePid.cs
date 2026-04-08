using Godot;
using System;
using PID;

public partial class MovePid : Node
{
    [Export] RigidBody3D ControlledNode = null;

    public Vector3 DesiredMove = Vector3.Zero;

    [Export] public bool MoveControl = false;

	[Export]Vector3 MovePID = new Vector3(0.01F,0.01F,0.01F);

    [Export]public bool MoveExcludeX = false;
    [Export]public bool MoveExcludeY = false;
    [Export]public bool MoveExcludeZ = false;

	[Export]float MoveImpulseClamp = 100F;

	V3PID MovePIDControl = new V3PID();

    

	public override void _PhysicsProcess(double delta)
	{
        if(ControlledNode != null){
            if (MoveControl)
            {
                MovePIDControl.P = MovePID.X;
                MovePIDControl.I = MovePID.Y;
                MovePIDControl.D = MovePID.Z;
                Vector3 MoveError = DesiredMove - ControlledNode.LinearVelocity;
                Vector3 MoveNew = MovePIDControl.newVector(ControlledNode.LinearVelocity,DesiredMove,(float)delta);
                if(MoveExcludeX) MoveNew.X = 0;
                if(MoveExcludeY) MoveNew.Y = 0;
                if (MoveExcludeZ) MoveNew.Z = 0;
                ControlledNode.ApplyImpulse(MoveNew);
            }
        }
		base._PhysicsProcess(delta);
	}

}
