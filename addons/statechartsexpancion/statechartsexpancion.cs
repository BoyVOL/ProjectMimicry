#if TOOLS
using Godot;
using System;

[Tool]
public partial class statechartsexpancion : EditorPlugin
{ 
	String GlobalPath;

	public override void _EnterTree()
	{
        GlobalPath = ((Resource)GetScript()).ResourcePath.GetBaseDir();
		// Initialization of the plugin goes here.
        AddCustomType("StateDebug", "Node", GD.Load<Script>(GlobalPath + "/StateDebug/StateDebug.cs"),
        GD.Load<Texture2D>(GlobalPath + "/StateDebug/icon.png"));
		GD.Print("statechartsexpancion loaded");
	}

	public override void _ExitTree()
	{
		// Clean-up of the plugin goes here.
		RemoveCustomType("StateDebug");
		GD.Print("statechartsexpancion unloaded");
	}
}
#endif
