using Godot;
using System;

public partial class TestPlayer : RigidBody3D
{
	[Export]public String EventMoveUp = "MoveUp";    
	
	[Export]public String EventMoveDowm = "MoveDown";
	[Export]public String EventMoveLeft = "MoveLeft";
	[Export]public String EventMoveRight = "MoveRight";

	[Export]float MovementSpeed = 10;

	[Export]float MoveP = 0.01F;
	
	[Export]float MoveI = 0.01F;
	[Export]float MoveD = 0.01F;

	[Export]float MoveImpulseClamp = 100F;

	V3PID MovePID = new V3PID();

	public Vector3 GetMovementVector()
	{
		Vector3 Result = Vector3.Zero;
		
		if (Input.IsActionPressed(EventMoveLeft)){
			Result.X -= 1;
		}
		if (Input.IsActionPressed(EventMoveRight)){
			Result.X += 1;
		}
		if (Input.IsActionPressed(EventMoveUp)){
			Result.Z -= 1;
		}
		if (Input.IsActionPressed(EventMoveDowm))
		{
			Result.Z += 1;
		}
		return Result;
	}

	public override void _PhysicsProcess(double delta)
	{
		MovePID.P = MoveP;
		MovePID.I = MoveI;
		MovePID.D = MoveD;
		Vector3 DesiredSpeed = MovementSpeed*GetMovementVector();
		Vector3 Error = DesiredSpeed - LinearVelocity;
		Vector3 New = MovePID.newVector(Error,(float)delta);
		ApplyImpulse(new Vector3(New.X, 0, New.Z));
		base._PhysicsProcess(delta);
	}

}
