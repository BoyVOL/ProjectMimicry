using Godot;
using System;
using GodotStateCharts;
using System.ComponentModel;

public partial class StateChartHandler : Node
{
    [Export] public Node ChartNode = null;

    StateChart Chart = null;

    public override void _EnterTree()
    {
        if (ChartNode != null)
        {
            Chart = StateChart.Of(ChartNode);
        }
        base._EnterTree();
    }
}
