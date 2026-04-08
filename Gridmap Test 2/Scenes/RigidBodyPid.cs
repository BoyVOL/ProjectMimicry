using Godot;
using System;

public partial class RigidBodyPid : Node
{
    [Export] RigidBody3D ControlledNode = null;

    public Vector3 DesiredMove = Vector3.Zero;
    public Quaternion DesiredAngle = Quaternion.FromEuler(Vector3.Zero);

    [Export] public bool MoveControl = false;

	[Export]Vector3 MovePID = new Vector3(0.01F,0.01F,0.01F);

    [Export]public bool MoveExcludeX = false;
    [Export]public bool MoveExcludeY = false;
    [Export]public bool MoveExcludeZ = false;

	[Export]float MoveImpulseClamp = 100F;

	V3PID MovePIDControl = new V3PID();

    [Export] public bool AngleControl = false;

	[Export]Vector3 AnglePID = new Vector3(0.01F,0.01F,0.01F);

    [Export]public bool AngleExcludeX = false;
    [Export]public bool AngleExcludeY = false;
    [Export]public bool AngleExcludeZ = false;

	[Export]float AngleImpulseClamp = 100F;

	QPID AnglePIDControl = new QPID();

    

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
            if (AngleControl)
            {
                AnglePIDControl.P = AnglePID.X;
                AnglePIDControl.I = AnglePID.Y;
                AnglePIDControl.D = AnglePID.Z;
                GD.Print(ControlledNode.Quaternion);
                Vector3 Impulse = AnglePIDControl.newVector(ControlledNode.Quaternion,DesiredAngle,(float)delta);
                if(AngleExcludeX) Impulse.X = 0;
                if(AngleExcludeY) Impulse.Y = 0;
                if (AngleExcludeZ) Impulse.Z = 0;
                ControlledNode.ApplyTorqueImpulse(Impulse);
            }
        }
		base._PhysicsProcess(delta);
	}
}
