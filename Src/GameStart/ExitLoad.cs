using Godot;
using System;
using Tool.LoadExpand;

public partial class ExitLoad : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var insNode = GD.Load<PackedScene>("res://Tscn/UI/Exit.tscn").Instantiate();
		var ui = insNode.GetNode<AnimatedSprite2D>("Assets");
		ui.GetParent().RemoveChild(ui);
		ui.Owner = null;
		this.AddChild(ui);
		insNode.QueueFree();
		
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
