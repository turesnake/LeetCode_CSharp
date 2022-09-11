using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    0070: 爬楼梯


    动态规划 一阶
*/

public class A_0070
{


    public static int ClimbStairs(int n) 
    {
        if( n==1 )
        {
            return 1;
        }
        int[] dp = new int[n+1];
        dp[0] = 1; // 0 阶
        dp[1] = 1; // 1 阶

        for( int i=2; i<n+1; i++ )
        {
            dp[i] = dp[i-1] + dp[i-2];
        }
        return dp[n];
    }
    

}





