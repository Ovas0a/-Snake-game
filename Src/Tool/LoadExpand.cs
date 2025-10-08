using System;
using Godot;
namespace Tool.LoadExpand;

public static class LoadExpand
{

    //此类是针对一个场景文件里面,其根节点里，有且仅有一个子节点的加载功能拓展
    //针对一个有且仅有一个子节点的场景，称为资源场景
    public static class Tscn
    {

        //传入一个场景的路径，返回该场景的根节点
        public static Node LoadRoot(string path)
        {
            return GD.Load<PackedScene>(path).Instantiate<Node>();
        }
        
        //此方法 给定一个 场景文件的地址，返回该场景仅有的一个子节点，
        //并且会对无用的根节点销毁 来节约内存
        //也可以通过泛型指定返回类型 LoadFirstNode<T>(string path)
        #region LoadFristNode()
        public static Node LoadFirstNode(string path)
        {
            var Root = LoadRoot(path);
            var FristNode = Root.GetChild(0);
            Root.RemoveChild(FristNode);
            
            FristNode.Owner = null;
            Root.QueueFree();
            return FristNode;
        }
        public static T LoadFirstNode<T>(string path) where T : Node
        {
            return LoadFirstNode(path) as T;
        }
        #endregion


    }









}