using Godot;
using System;

public partial class PlayerCharacter : Node2D
{
    [Export]public String EventMoveUp = "MoveUp";    
    
    [Export]public String EventMoveDowm = "MoveDown";
    [Export]public String EventMoveLeft = "MoveLeft";
    [Export]public String EventMoveRight = "MoveRight";

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
        if (@event.IsActionPressed(EventMoveUp))
        {
            GD.Print("Up");
        }
        if (@event.IsActionPressed(EventMoveDowm))
        {
            GD.Print("Down");
        }
        if (@event.IsActionPressed(EventMoveLeft))
        {
            GD.Print("Left");
        }
        if (@event.IsActionPressed(EventMoveRight))
        {
            GD.Print("Right");
        }
    }

}
