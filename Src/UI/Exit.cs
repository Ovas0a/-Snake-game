using Godot;
using System;

public partial class Exit : AnimatedSprite2D
{
	private string text;

	public string Text
	{
		get
		{
			return GetNode<Label>("Text").Text;
		}
		set
		{
			GetNode<Label>("Text").Text = Text;
		}

	}
	
	private bool mouserIsRect=false;
	
	public override void _Ready()
    {
    }


	public override void _Process(double delta)
	{
		

    }
	
	private void press()
	{
		GetTree().Quit();
    }
	private void Mouser_entered()
	{
		mouserIsRect = true;
		this.Play();

	}
	private void exited()
	{
		mouserIsRect = false;
		Stop();
	}
	

}
