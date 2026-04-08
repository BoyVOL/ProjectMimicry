using Godot;
using System;
using PID;

public partial class AnglePid : Node
{
    public Quaternion DesiredAngle = Quaternion.FromEuler(Vector3.Zero);

    [Export] RigidBody3D ControlledNode = null;
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
            if (AngleControl)
            {
                AnglePIDControl.P = AnglePID.X;
                AnglePIDControl.I = AnglePID.Y;
                AnglePIDControl.D = AnglePID.Z;
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
