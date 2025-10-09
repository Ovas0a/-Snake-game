using Godot;
using System;
using System.Security.Cryptography.X509Certificates;
using Tool.LoadExpand;

public partial class ExitLoad : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.AddChild(LoadExpand.Tscn.LoadFirstNode("res://Tscn/UI/Exit.tscn"));
		
		
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}


    public override void _Input(InputEvent @event)
    {
		base._Input(@event);
		if(@event is InputEventKey || @event is InputEventMouseButton)
		{
			
			
			var mousePos = GetGlobalMousePosition();
			var exitRect = this.GetChild<AnimatedSprite2D>(0).GetNode<Button>("Button").GetGlobalRect();
			if (!exitRect.HasPoint(mousePos))
			{
				 GetTree().ChangeSceneToFile("res://Tscn/Games.tscn");
			}
			
        }
    }

}
