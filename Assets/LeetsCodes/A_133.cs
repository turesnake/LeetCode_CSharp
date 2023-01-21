using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeB;


/*
    133. 克隆图

    深度拷贝一张图
    
    
    bfs ? 


    请把 bfs 和 dfs 都实现

*/
public class A_133
{

    Dictionary<int,Node> map = new Dictionary<int,Node>();    

    // !!!! 这个容器仅被 CloneGraph_BFS_1() 用到, 其实可以被优化掉, 在 CloneGraph_BFS_2() 中... 
    Dictionary<int,List<int>> neighborIDs = new Dictionary<int, List<int>>(); 


    // 参数是图的 节点1
    // 老方法, 需要使用 neighborIDs
    public Node CloneGraph_BFS_1(Node node) 
    {
        if( node == null ) 
        {
            return null;
        }

        LinkedList<Node> deque = new LinkedList<Node>();
        deque.AddLast(node);

        // 遍历图, 找出所有 node
        while( deque.Count > 0 ) 
        {
            var nd = deque.First.Value;
            deque.RemoveFirst();
            //--
            if( map.ContainsKey(nd.val) == false ) 
            {                
                map.Add( nd.val, new Node(nd.val) );
                //--
                var lis = nd.neighbors.Select( x=>x.val ); // linq 版
                neighborIDs.Add( nd.val, new List<int>(lis) );
                //--
                foreach( var e in nd.neighbors ) 
                {
                    deque.AddLast(e);
                }
            }
        }

        foreach( var p in map ) 
        {
            Node tNode = p.Value;
            foreach( var id in neighborIDs[p.Key] ) 
            {
                tNode.neighbors.Add( map[id] );
            }
        }

        return map[1];
    }



    // 尝试新方法, 借用原始 node 的 neighbors 来暂存信息;
    public Node CloneGraph_BFS_2(Node node) 
    {
        if( node == null ) 
        {
            return null;
        }

        LinkedList<Node> deque = new LinkedList<Node>();
        deque.AddLast(node);

        // 遍历图, 找出所有 node
        while( deque.Count > 0 ) 
        {
            var nd = deque.First.Value;
            deque.RemoveFirst();
            //--
            if( map.ContainsKey(nd.val) == false ) 
            {                
                var newNode = new Node(nd.val);
                newNode.neighbors = nd.neighbors; // 暂用
                map.Add( nd.val, newNode );
                //--
                foreach( var e in nd.neighbors ) 
                {
                    deque.AddLast(e);
                }
            }
        }

        foreach( var p in map ) 
        {
            var neighbors = p.Value.neighbors;

            List<Node> nbs = new List<Node>();
            foreach( var oldE in neighbors ) 
            {
                nbs.Add(map[oldE.val]);
            }
            p.Value.neighbors = nbs;
        }

        return map[1];
    }


    
    public static void Main() 
    {
        //var instance = new A_133();
    }

}




/*
    dfs 版:  十分精巧
*/
public class A_133_DFS_1
{
    Dictionary<int, Node> map = new Dictionary<int, Node>();

    // 参数:  旧的   node
    // ret:  新建的 node
    public Node CloneGraph(Node node) 
    {
        if( node == null ) 
        {
            return null;
        }

        if( map.ContainsKey(node.val) == true ) 
        {
            return map[node.val];
        }

        var newNode = new Node(node.val);
        map.Add( newNode.val, newNode );
        
        foreach( var e in node.neighbors ) 
        {
            var k = CloneGraph(e);
            newNode.neighbors.Add( k );
        }

        return newNode;
    }

}




