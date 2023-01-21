using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    1971: 寻找图中是否存在路径

    无向图, 

    并查集 (先尝试自己创建一个 并查集...)
*/
public class A_1971
{

    int[] ary;

    int FindRoot( int current_ ) 
    {
        if( ary[current_] == current_ ) 
        {
            return current_;
        }
        int ret = FindRoot( ary[current_] );
        ary[current_] = ret; // 及时修改自己的 parent, 让层级扁平化;
        return ret;
    }

    
    public bool ValidPath( int n, int[][] edges, int source, int destination ) 
    {

        // 初始化容器, 每个元素的 root 都是自己
        ary = new int[n];
        for( int i=0; i<n; i++ ) 
        {
            ary[i] = i;
        }

        // 建立并查集数据
        foreach( var e in edges ) 
        {
            int root0 = FindRoot( e[0] );
            int root1 = FindRoot( e[1] );
            if( root0 != root1 ) 
            {
                ary[root0] = root1;
            }
        }
        
        return FindRoot(source) == FindRoot(destination);
    }

    
    

    public static void Main() 
    {
        var instance = new A_1971();



        int[][] edges = {
            new int[]{4,3},
            new int[]{1,4},
            new int[]{4,8},
            new int[]{1,7},
            new int[]{6,4},
            new int[]{4,2},
            new int[]{7,4},
            new int[]{4,0},
            new int[]{0,9},
            new int[]{5,4}
        };


        bool ret = instance.ValidPath( 10, edges, 5, 9 );
        Debug.Log( "ret = " + ret );

    }


}






