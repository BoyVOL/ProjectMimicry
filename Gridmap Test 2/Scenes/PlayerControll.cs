using Godot;
using System;

public partial class PlayerControll : Node
{
	[Export]public String EventMoveUp = "MoveUp";    
	
	[Export]public String EventMoveDowm = "MoveDown";
	[Export]public String EventMoveLeft = "MoveLeft";
	[Export]public String EventMoveRight = "MoveRight";

	[Export]float MovementSpeed = 10;

	[Export] MovePid PIDNode = null;

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
		if(PIDNode != null)
		{
			PIDNode.DesiredMove = MovementSpeed*GetMovementVector();
		}
		base._PhysicsProcess(delta);
	}
}
