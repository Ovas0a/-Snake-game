using Godot;
using System;

//旋转动画
public partial class Node2d_Rotate : Node2D
{
	[Export]
	public bool isPlay = false;

	[Export]
	//最大旋转允许度
	public float maxDegree = 360;
	[Export]
	public float minDegree = 0;
	[Export]
	//每次选择多少度
	public float Speed = 5;
	[Export]
	//每秒钟多少次
	public float tike = 20;
	private float timer = 0;
	private float time;
	public override void _Ready()
	{
		time = 1 / tike;
	}

		public override void _Process(double delta)
	{

		if (isPlay == true && this.RotationDegrees < maxDegree)
		{
			timer += (float)delta;
			if (timer < time) return;
			timer = 0;
			addRotaton(Speed);


		}
		else if (isPlay == false && this.RotationDegrees > minDegree)
		{

			timer += (float)delta;
			if (timer < time) return;
			timer = 0;

			addRotaton(-Speed);


		}








	}

	public void play()
	{
		isPlay = true;

	}
	public void stop()
	{
		isPlay = false;
	}
	//添加旋转度，num需要旋转的度数
	private void addRotaton(float num)
	{
		this.RotationDegrees += num;
	}
}
