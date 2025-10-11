using Godot;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Tool.LoadExpand;
public partial class Head : CharacterBody2D
{

	//多少个尾巴
	public int TileLen = 0;
	//速度
	public static float Speed = 300.0f;


	//蛇的移动向量的归一值
	private Vector2 Snake_Velocity = new Vector2(-1, 0);

	public Vector2 OldPos;
	
	public static Vector2 HeadTextureSize;

	



	public override void _Ready()
	{
		base._Ready();
		HotKey.Init();
		var size = this.GetNode<Sprite2D>("SnakeHead").Texture.GetSize();

		HeadTextureSize = new Vector2(size.X * Scale.X, size.Y * Scale.Y);


		this.addTile(1000);
		
	}


	public override void _PhysicsProcess(double delta)
	{
		OldPos = this.Position;



		//当前按下的键值
		//var preKey = LoadExpand.Tscn.GetVector(HotKey.MoveLeft, HotKey.MoveRight, HotKey.MoveTop, HotKey.MoveButtom);
		//测试区

		this.GetTree().CurrentScene.GetNode("cs").GetChild<Label>(0).Text = this.GetChild<Node2D>(1).GlobalPosition.ToString();

		//---


		//获取蛇到鼠标位置的向量
		var MousPos = GetGlobalMousePosition();

		Snake_Velocity = (MousPos - this.Position).Normalized();


		//移动操作
		this.Velocity = Snake_Velocity * Speed;
		//蛇头旋转操作
		var d = Mathf.RadToDeg(Mathf.Atan2(Snake_Velocity.Y, Snake_Velocity.X));
		this.RotationDegrees = d;








		MoveAndSlide();
	}








	//添加身体
	private void addTile(int loopNum)
	{
		//获取身体节点
		var tileNode = LoadExpand.Tscn.LoadFirstNode<Node2D>("res://Tscn/UI/SnakeTile.tscn");

		//如果是第一截身体，就先添加到头节点里，记录全局坐标。再添加到身体节点里，赋值全局坐标
		//如果是其他节点，先添加到某个具体身体节点内，记录全局坐标，再移动到身体节点内，赋值全局桌标

		if (TileLen == 0)
		{
			//获取位置偏移
			var num = this.GetNode<Sprite2D>("SnakeHead").Texture.GetSize().X * this.Scale.X / 2;
			tileNode.Position = new Vector2(tileNode.Position.X - num, tileNode.Position.Y);


			this.AddChild(tileNode);
			//记录全局坐标
			var GlobPos = tileNode.GlobalPosition;
			this.RemoveChild(tileNode);
			this.GetParent().GetNode("Tiles").AddChild(tileNode);
			tileNode.Position = GlobPos;
		}
		else
		{


			//获取兄弟节点
			var Tiles = this.GetParent().GetNode("Tiles");
			//获取Tiles最后一个子节点
			var Tile = Tiles.GetChild(Tiles.GetChildCount() - 1);

			//通过最后一个子节点获取位置偏移
			var spriteNode = Tile.GetNode<Sprite2D>("Ass");

			var num = spriteNode.Texture.GetSize().X * spriteNode.Scale.X / 2;

			tileNode.Position = new Vector2(tileNode.Position.X - num, tileNode.Position.Y);


			Tile.AddChild(tileNode);
			var GlobPos = tileNode.GlobalPosition;
			Tile.RemoveChild(tileNode);
			Tiles.AddChild(tileNode);
			tileNode.Position = GlobPos;
		}

		//位置放置完毕，在tilenode内部设置它的上一个节点用于移动判断
		((Tile)tileNode).SetBit(TileLen);

		TileLen++;
		loopNum--;
		if (loopNum != 0) addTile(loopNum);



	}





}
