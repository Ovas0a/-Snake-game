using Godot;
using System;
using Tool.Animation.Rect;
using Tool.LoadExpand;
public partial class System_Button : Button
{
	private Node2d_Rotate Rotate;
	private Rect_HL_Expand Expand;
	private (Texture2D Enter, Texture2D Exit) Assets;
	private TextureRect AssetsRect;

	public override void _Ready()
    {
		Rotate = this.GetParent<Node2d_Rotate>();
		
		Expand = this.GetTree().CurrentScene.GetNode("SytemAnimaExpand").GetChild<Rect_HL_Expand>(0);
		Assets.Enter = GD.Load<Texture2D>("res://Assets/SytemButtonent.png");
		Assets.Exit = GD.Load<Texture2D>("res://Assets/SytemButtonexit.png");
		AssetsRect = this.GetTree().CurrentScene.GetNode<TextureRect>("TextureRect");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void mouseEnter()
	{
		AssetsRect.Texture = Assets.Enter;
		Rotate.isPlay = true;
		Expand.play();
	}
	public void MouseExit()
	{
		 AssetsRect.Texture = Assets.Exit;
		var retc = Expand.GetGlobalRect();
		if (!retc.HasPoint(GetGlobalMousePosition()))
        {
			Rotate.isPlay = false;
			Expand.Stop();
			
        }
		
	}
}
