using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    797. 所有可能的路径

    
    有向无环图


    返回类型的问题:
    https://www.jianshu.com/p/26d2a9bc9727


*/

// 不是很好的办法, 无法消除 c# 版无法 Reverse 的问题, 
// 建议参考下方 Solution_797_1 中的解法;
public class A_797
{

    IList<IList<int>> answers = new List<IList<int>>();

    int[][] m_graph;
    int n;
    
    List<int> Rec( int current )
    {
        if( current == n-1 ) 
        {
            answers.Add( new List<int>(){current} );
            return new List<int>{ answers.Count-1 };
        }

        List<int> rets = new List<int>();

        foreach( var e in m_graph[current] ) 
        {
            
            var r = Rec( e );
            rets.AddRange( r );
            foreach( var idx in r ) 
            {
                answers[idx].Add( current );
            }
        }
        return rets;
    }



    public IList<IList<int>> AllPathsSourceTarget( int[][] graph ) 
    {
        m_graph = graph;
        n = graph.Length;

        Rec( 0 );

        // 此处存在问题, answers 中元素 调用 Reverse() 无效...

        IList<IList<int>> ans = new List<IList<int>>();

        foreach( var e in answers ) 
        {
            var j = (List<int>)e;
            j.Reverse();
            ans.Add(j);
        }

        return ans;
    }


    public static void Main() 
    {
        var instance = new A_797();

        int[][] graph = {
            new int[]{1,2},
            new int[]{3},
            new int[]{3},
            new int[]{}
        };

        var ret = instance.AllPathsSourceTarget(graph);

        foreach( var j in ret )
        {
            string s = "";
            foreach(  var i in j ) 
            {
                s += i + ", ";
            }
            Debug.Log( s );
        }
    }


}



/*
    评论区方案:

    依然是 dfs, 全程使用一个临时的 list: temp 来记录当前 stack 中元素内容;
    随着 dfs 的下潜和上浮, 这个 temp 中的元素也对应的删除增加;
    当满足条件时, 就把此时的 temp 复制进 allPaths 中;


*/
public class Solution_797_1
{
    IList<IList<int>> allPaths = new List<IList<int>>();
    IList<int> temp = new List<int>(); // !!! 核心 !!!!
    int n;
    int[][] graph;

    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        this.n = graph.Length;
        this.graph = graph;
        Backtrack(0);
        return allPaths;
    }

    public void Backtrack(int node) 
    {
        temp.Add(node);

        if (node == n - 1) 
        {
            allPaths.Add(new List<int>(temp)); // 复制
        } 
        else 
        {
            int[] nextNodes = graph[node];
            foreach (int next in nextNodes) 
            {
                Backtrack(next);
            }
        }

        temp.RemoveAt(temp.Count - 1);
    }
}






