using Godot;
using System;
using System.Reflection;

namespace Tool.Animation.Rect;
//此动画预设 仅能搭配  TextureRect  节点对象
//效果：isPlay=true时，节点对象的大小从左到右裁剪展开
// isPlay=false时，回退
public partial class Rect_HL_Expand : TextureRect
{

	[Export]
	private bool isPlay = false;

	//每秒执行多少次
	[Export]
	private float tike = 120;

	//每次拓展多少像素
	[Export]
	private float Pix = 30;
	//计时器
	private float timer = 0;
	private float time;
	private Vector2 TextureSize;

	public override void _Ready()
	{
		TextureSize = this.Texture.GetSize();
		time = 1 / tike;
		ExpandMode = TextureRect.ExpandModeEnum.IgnoreSize;
		StretchMode = TextureRect.StretchModeEnum.Tile;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (isPlay == true && this.Size.X < TextureSize.X)
		{
			timer += (float)delta;
			if (timer < time) return;
			timer = 0;

			//播放
			var setX = this.Size.X + Pix;
			//判断又无越界
			if (setX > TextureSize.X) setX = TextureSize.X;
			this.Size = new Vector2(setX, this.Size.Y);


		}
		else if (isPlay == false && this.Size.X > 0)
		{
			timer += (float)delta;
			if (timer < time) return;
			timer = 0;


			//回播放
			this.Size = new Vector2(this.Size.X - Pix, this.Size.Y);
		}

	}
	public void play()
	{
		isPlay = true;
	}
	public void Stop()
	{
		isPlay = false;
	}

}
