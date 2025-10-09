using Godot;
using System;
using Tool.LoadExpand;

public partial class SytemAnimaExpand : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.AddChild(LoadExpand.Tscn.LoadFirstNode("res://Tscn/UI/AnimaSystemExpand.tscn"));

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}






}
