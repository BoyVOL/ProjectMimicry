using Godot;
using System;

public partial class PlayerCharacter : Node2D
{
    [Export]public String EventMoveUp = "MoveUp";    
    
    [Export]public String EventMoveDowm = "MoveDown";
    [Export]public String EventMoveLeft = "MoveLeft";
    [Export]public String EventMoveRight = "MoveRight";
}
