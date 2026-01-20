using Godot;
using System;

public partial class PlayerCharacter : Node2D
{
    [Export]public String EventMoveUp = "MoveUp";    
    
    [Export]public String EventMoveDowm = "MoveDown";
    [Export]public String EventMoveLeft = "MoveLeft";
    [Export]public String EventMoveRight = "MoveRight";
    [Export]public AnimationPlayer Player;

    [Export]float MovementSpeed = 10;

    public Vector2 GetMovementVector()
    {
        Vector2 Result = Vector2.Zero;
        
        if (Input.IsActionPressed(EventMoveLeft)){
            Result.X -= 1;
        }
        if (Input.IsActionPressed(EventMoveRight)){
            Result.X += 1;
        }
        if (Input.IsActionPressed(EventMoveUp)){
            Result.Y -= 1;
        }
        if (Input.IsActionPressed(EventMoveDowm))
        {
            Result.Y += 1;
        }
        return Result;
    }

    public override void _EnterTree()
    {
        base._EnterTree();
        if(Player != null)
        {
            Player.Play("new_animation");
        }
    }


    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        Position+=GetMovementVector()*MovementSpeed*(float)delta;
    }

}
