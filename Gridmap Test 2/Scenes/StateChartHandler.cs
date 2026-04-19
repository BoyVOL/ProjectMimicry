using Godot;
using System;
using GodotStateCharts;
using System.ComponentModel;

public partial class StateChartHandler : Node
{
    [Export] public Node StateNode = null;

    StateChartState State = null;

    public override void _EnterTree()
    {
        if (StateNode != null)
        {
            State = StateChartState.Of(StateNode);
            State.StateEntered += () => GD.Print("Entered!");
        }
        base._EnterTree();
    }
}
