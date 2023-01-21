using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    684. 冗余连接

    
    
    检测图中的环, 用并查集来实现, 只要发现两个点的 root 已经相同了, 就说明目前这条边就是 环的最后一条边;


*/
public class A_684
{

    int n;
    int[] ents;

    int FindRoot( int current ) 
    {
        if( ents[current] == current ) 
        {
            return current;
        }
        ents[current] = FindRoot( ents[current] );
        return ents[current];
    }

    public int[] FindRedundantConnection( int[][] edges ) 
    {
        n = edges.Length;
        ents = new int[n];

        // 初始化并查集
        for( int i=0; i<n; i++ ) 
        {
            ents[i] = i;
        }

        int[] ret = null;

        foreach( var e in edges ) 
        {
            int root0 = FindRoot(e[0]-1);
            int root1 = FindRoot(e[1]-1);
            if( root0 == root1 ) 
            {
                ret = e;
                break;
            }
            else 
            {
                ents[root0] = root1;
            }
        }
        return ret;
    }
     

    public static void Main() 
    {
        var instance = new A_684();


        int[][] edges = {
            new int[]{1,2},
            new int[]{1,3},
            new int[]{2,3}
        };


        var ret = instance.FindRedundantConnection( edges );
        Debug.Log( ret[0] + ", " + ret[1] );
        

    }

}






