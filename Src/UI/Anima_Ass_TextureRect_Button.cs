using Godot;
using System;

public partial class Anima_Ass_TextureRect_Button : Button
{
	private (Texture2D Enter, Texture2D Exit) Assets;
	private TextureRect AssetsRect;
	public override void _Ready()
    {
        Assets.Enter = GD.Load<Texture2D>("res://Assets/SytemButtonent.png");
		Assets.Exit = GD.Load<Texture2D>("res://Assets/SytemButtonexit.png");
		AssetsRect = this.GetParent<TextureRect>();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	public void mouseEnter()
	{
		AssetsRect.Texture = Assets.Enter;
	}
	public void MouseExit()
	{
		AssetsRect.Texture = Assets.Exit;
	}

	public void returnPress()
    {
		this.GetTree().ChangeSceneToFile("res://Tscn/GameStart.tscn");
    }

}
