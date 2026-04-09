using Godot;
using System;

public partial class MouseCamera : Camera3D
{
    [Export] float scale = 0.1F;
    Vector2 MousePosition;

    Viewport viewport;

    public override void _EnterTree()
    {
        viewport = GetViewport();
        base._EnterTree();
    }

    public override void _Process(double delta)
    {
        MousePosition = viewport.GetMousePosition();
        Rect2 ViewRect = viewport.GetVisibleRect();
        Vector2 Center = ViewRect.GetCenter();
        if (MousePosition.X < ViewRect.Position.X) MousePosition.X = ViewRect.Position.X;
        if (MousePosition.Y < ViewRect.Position.Y) MousePosition.Y = ViewRect.Position.Y;
        if(MousePosition.X > ViewRect.Size.X) MousePosition.X = ViewRect.Size.X;
        if(MousePosition.Y > ViewRect.Size.Y) MousePosition.Y = ViewRect.Size.Y;
        Vector2 Shift = MousePosition - Center;
        HOffset = Shift.X*scale;
        VOffset = -Shift.Y*scale;
        base._Process(delta);
    }
}
