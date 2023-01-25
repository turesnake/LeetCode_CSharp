using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    787. K 站中转内最便宜的航班


    Bellman_ford;

    以 src 为起点, 计算整张图, 直到充分迭代后, 查看 dst 位置的 w值;


    尚未完成...


*/
public class A_787
{

    struct Node 
    {
        public int idx;
        public int roadW; // road weight
        public Node( int idx_, int roadW_ ) 
        {
            idx = idx_;
            roadW = roadW_;
        }
    }


    int _n;
    int[][] _flights;
    int _src; 
    int _dst;
    int _k;

    int[] weights;
    int[] ks;
    bool[] dirtyFlags;

    LinkedList<int> deque = new LinkedList<int>();
    List<List<Node>> datas = new List<List<Node>>();



    bool BellmanFord() 
    {
        bool isDirty = false;
        deque.Clear();
        deque.AddLast(_src);
        Array.Fill( dirtyFlags, false );


        while( deque.Count > 0 ) 
        {
            int id = deque.First.Value;
            deque.RemoveFirst();

            //---:
            dirtyFlags[id] = true;

            foreach( var node in datas[id] ) 
            {
                if( dirtyFlags[node.idx] == true ) 
                {
                    continue;
                }

                if(     ks[id] + 1 <= _k 
                    &&  weights[node.idx] > weights[id] + node.roadW 
                ){
                    isDirty = true;
                    weights[node.idx] = weights[id] + node.roadW;
                    ks[node.idx] = ks[id] + 1;
                }
                deque.AddLast( node.idx );
            }
        }

        // 有的 节点可能没有被遍历到, 那是因为没有其它节点 指向它;
        // 它的 w 值将始终为 max; 意味着从 src 无法到达这个点

        return isDirty;
    }
    

    public int FindCheapestPrice( int n, int[][] flights, int src, int dst, int k ) 
    {
        _n = n;
        _flights = flights;
        _src = src;
        _dst = dst;
        _k = k + 1;

        weights = new int[_n];
        Array.Fill( weights, int.MaxValue );
        weights[src] = 0;

        ks = new int[_n];
        Array.Fill( ks, int.MaxValue );


        dirtyFlags = new bool[_n];


        for( int i=0; i<n; i++ ) 
        {
            datas.Add( new List<Node>() );
        }

        foreach( var e in flights )
        {
            datas[e[0]].Add( new Node( e[1], e[2] ) );
        }

        for( int i=0; i<_n-1; i++ ) 
        {
            //Debug.Log("do");
            bool ret = BellmanFord();
            if( ret == false ) 
            {
                break;
            }
        }

        // debug:
        // string s = "";
        // for( int i=0; i<n; i++ )
        // {
        //     s += "\n[" + i + "]";
        //     foreach( var e in datas[i] ) 
        //     {
        //         s += "\n    " + e.idx + ": " + e.roadW;
        //     }
        // } 
        // Debug.Log(s);

        // for( int i=0; i<n; i++ )
        // {
        //     Debug.Log( i + ": " + weights[i] );
        // }

        return 0;
    }



    
     

    public static void Main() 
    {
        var instance = new A_787();


        int[][] flights = {
            new int[]{ 0,1,5 },
            new int[]{ 0,5,-2 },
            new int[]{ 1,2,1 },
            new int[]{ 2,5,2 },
            new int[]{ 2,3,3 },
            new int[]{ 2,4,7 },
            new int[]{ 4,3,10 },
            new int[]{ 5,1,2 },
            new int[]{ 5,4,3 }
        };


        int ret = instance.FindCheapestPrice( 6, flights, 1, 4, 3 );

    }

}






