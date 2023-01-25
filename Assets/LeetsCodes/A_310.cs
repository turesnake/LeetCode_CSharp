using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    851. 喧闹和富有


    拓扑排序 入度+bfs

    不需要 单调栈, 只需要反向实现 拓扑排序即可:
    

*/
public class A_310
{
    class Node 
    {
        public int inDegree = 0;
        public int deep = 0;
        public List<int> neighbors = new List<int>();
    }


    Node[] nodes;



    public IList<int> FindMinHeightTrees(int n, int[][] edges) 
    {

        nodes = new Node[n];
        for( int i=0; i<n; i++ ) 
        {
            nodes[i] = new Node();
        }

        foreach( var e in edges ) 
        {
            nodes[e[0]].inDegree++;
            nodes[e[1]].inDegree++;
            nodes[e[0]].neighbors.Add(e[1]);
            nodes[e[1]].neighbors.Add(e[0]);
        }


        int maxDeep = 0;

        LinkedList<int> deque = new LinkedList<int>();
        for( int i=0; i<n; i++ ) 
        {
            if( nodes[i].inDegree == 1 )
            {
                deque.AddLast(i);
            }
        }

        while( deque.Count > 0 ) 
        {
            int id = deque.First.Value;
            deque.RemoveFirst();
            var node = nodes[id];
            //---
            
            foreach( var j in node.neighbors ) 
            {
                if( nodes[j].inDegree > 1 )
                {
                    nodes[j].inDegree--;
                    nodes[j].deep = Math.Max( nodes[j].deep, node.deep+1 );
                    maxDeep = Math.Max( maxDeep, nodes[j].deep );
                    if( nodes[j].inDegree == 1 ) 
                    {
                        deque.AddLast( j );
                    }
                }
            }
        }

        
        List<int> ret = new List<int>();
        for( int i=0; i<n; i++ ) 
        {
            if( nodes[i].deep == maxDeep )
            {
                ret.Add( i );
            }
        }
        return ret;
    }
    



     

    public static void Main() 
    {
        var instance = new A_310();

        int[][] edges = {
            new int[]{0,1},
            new int[]{0,2},
            new int[]{1,3},
            new int[]{1,4},
            new int[]{1,5},
            new int[]{3,9},
            new int[]{4,7},
            new int[]{4,6},
            new int[]{6,8}
        };

        instance.FindMinHeightTrees( 10, edges );

    }

}










