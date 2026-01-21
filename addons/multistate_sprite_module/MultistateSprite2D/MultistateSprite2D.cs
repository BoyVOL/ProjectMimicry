using Godot;
using System;

[Tool]
[GlobalClass]
public partial class MultistateSprite2D : Sprite2D
{
    [Export]Texture2D[] States = new Texture2D[4];
}
