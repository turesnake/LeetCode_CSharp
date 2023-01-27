using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeC;


/*
    96. 不同的二叉搜索树

    有点类似 动态规划, 从 n=1 开始逐个计算每一种的可能性

*/

public class A_96
{
    
    public int NumTrees( int n )
    {

        int[] rets = new int[n+1];
        rets[0] = 1; // 分配 0个, 只有一种情况
        rets[1] = 1; // 分配 1个, 有一种情况

        for( int i=2; i<=n; i++ ) 
        {
            int num = i-1;
            // 在 root 下分配 i-1 个元素:
            for( int j=0; j<=num; j++ )
            {
                rets[i] += rets[j] * rets[num-j];
            }
        }
        return rets[n];
    }


    public static void Main() 
    {
        var instance = new A_96();

        

        
    
    }
    
}





