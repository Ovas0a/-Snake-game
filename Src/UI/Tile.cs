using Godot;
using System;
using System.Text.Json.Serialization.Metadata;

public partial class Tile : CharacterBody2D
{
	public float Speed = 300.0f;

	//此节点的上一个节点
	public Node2D PreviousNode;
	public Vector2 OldPos;

	//此节点是第多少位身体
	private int Bit;

	public Vector2 TextureSize;

    public override void _Ready()
    {
		base._Ready();
		Speed = Head.Speed;
		var size = this.GetNode<Sprite2D>("Ass").Texture.GetSize();
		TextureSize = new Vector2(size.X * Scale.X,size.Y*Scale.Y);
    }




	public override void _PhysicsProcess(double delta)
	{
		


		var v = (PreviousNode.Position - this.Position);

		float num;
		if (Bit == 0) num = TextureSize.X + Head.HeadTextureSize.X / 2-6;
		else num = TextureSize.X;
		num += 4;   //4

		//判断距离
		var l = GetLen(v);

		//归一
		var vNor = v.Normalized();

		
		
		this.Velocity = vNor * Speed * (l / num);
		
	


		//旋转角度
		this.RotationDegrees=Mathf.RadToDeg(Mathf.Atan2(vNor.Y, vNor.X));
		
		

		


		MoveAndSlide();
	}

	//当节点添加到目标位置后，设置Bit属性，PreviousNode赋值前一个节点
	public void SetBit(int num)
	{
		Bit = num;
		//首节点  上一个节点是头
		if (Bit == 0)
        {
			PreviousNode = this.GetTree().CurrentScene.GetNode("Snake").GetNode<Node2D>("Head");
        }
        else  //不是首节点，通过Bit获取上一个节点 Bit-1
		{

			PreviousNode = this.GetParent().GetChild<Node2D>(Bit - 1);
        }

    }

	public float GetLen(Vector2 v)
	{
		return Mathf.Sqrt(v.X * v.X + v.Y * v.Y);
    }

}
