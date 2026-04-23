using Godot;
using GodotStateCharts;
using System;

public partial class StateDebug : Node
{
    [Export] Node State = null;

    StateChartState WrappedState = null;

    public override void _EnterTree()
    {
        if (State != null)
        {
            WrappedState = StateChartState.Of(State);
        }
        base._EnterTree();
    }

    public override void _Process(double delta)
    {
        GD.Print(WrappedState.Active);
        base._Process(delta);
    }
}
