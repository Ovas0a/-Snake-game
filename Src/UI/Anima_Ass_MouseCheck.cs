using Godot;
using System;
using Tool.Animation.Rect;

public partial class Anima_Ass_MouseCheck : CharacterBody2D
{



    public override void _Ready()
    {
		base._Ready();
		
    }


	public override void _PhysicsProcess(double delta)
	{

		



    }



	public void mouseEnter()
    {
    }
	public void MouseExit()
	{
		if (this.GetParent<Control>().Size.X > 0)
		{
			this.GetParent<Rect_HL_Expand>().Stop();
			this.GetTree().CurrentScene.GetNode<Node2d_Rotate>("System").isPlay = false;
		}
	}
	

}
