using Godot;
using System;

public partial class Snake : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		QueueRedraw();
    }



	//绘制法线
	public override void _Draw()
	{
		base._Draw();
		DrawLine(new Vector2(0, 0), this.GetNode<Node2D>("Head").Position, new Color(255, 0, 0), 8);
	}
}
