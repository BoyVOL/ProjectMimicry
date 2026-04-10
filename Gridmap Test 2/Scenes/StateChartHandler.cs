using Godot;
using System;
using GodotStateCharts;

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
        GD.Print(Chart.ToString());
        base._EnterTree();
    }
}
