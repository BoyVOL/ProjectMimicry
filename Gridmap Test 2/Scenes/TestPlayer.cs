using Godot;
using System;

public partial class TestPlayer : RigidBody3D
{
	[Export]public String EventMoveUp = "MoveUp";    
	
	[Export]public String EventMoveDowm = "MoveDown";
	[Export]public String EventMoveLeft = "MoveLeft";
	[Export]public String EventMoveRight = "MoveRight";

	[Export]float MovementSpeed = 10;

	[Export]float MoveP = 1;
	
	[Export]float MoveI = 1;
	[Export]float MoveD = 1;

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
		ApplyImpulse(MovementSpeed*GetMovementVector());
		MovePID.P = MoveP;
		MovePID.I = MoveI;
		MovePID.D = MoveD;
		base._PhysicsProcess(delta);
	}

}
