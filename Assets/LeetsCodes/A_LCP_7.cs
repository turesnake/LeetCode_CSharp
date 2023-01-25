using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    LCP_07: 传递信息;


    暂时先用最简单的 dfs 递归 来解决...

    未来应该补上 迭代法 ...

    
*/
public class A_LCP_7
{

    /*
        
    */


    List<int>[] datas;
    int count = 0;

    void DFS( int n, int currentID_, int leftK_  )
    {
        if( leftK_ == 0 ) 
        {
            if(currentID_ == n-1)
            {
                count++;
            }
            return;
        }
        foreach( var e in datas[currentID_] ) 
        {
            DFS( n, e, leftK_-1 );
        }
    }


    
    public int NumWays( int n, int[][] relation, int k ) 
    {
        // 初始化容器:
        datas = new List<int>[n];
        for( int i=0; i<n; i++ ) 
        {
            datas[i] = new List<int>();
        }
        // 装填数据
        foreach( var p in relation ) 
        {
            datas[p[0]].Add( p[1] );
        }
        DFS( n, 0, k );
        return count;
    }



    public static void Main() 
    {
        var instance = new A_LCP_7();

        int[][] relation = { 
            new int[]{ 0,2 }, 
            new int[]{ 2,1 },
            new int[]{ 3,4 },
            new int[]{ 2,3 },
            new int[]{ 1,4 },
            new int[]{ 2,0 },
            new int[]{ 0,4 }
        };
        int ret = instance.NumWays( 5, relation, 3 );
        Debug.Log( "ret = " + ret );
    }


    
    
}

