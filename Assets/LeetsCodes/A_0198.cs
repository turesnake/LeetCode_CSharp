using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    0198: 打家劫舍


    动态规划 n*2
*/

public class A_0198
{

    // 每一格 记录自己: 选择偷时的最大收益, 选择不偷时的最大收益
    // 新的一格: (1)本次偷+上次不偷;  (2)本次不透+ (上次偷 或 不偷)
    public static int Rob(int[] nums) 
    {
        int len = nums.Length;
        int[,] dp = new int[len,2];

        dp[0,0] = nums[0]; // 偷
        dp[0,1] = 0;       // 不偷

        for( int i=1; i<len; i++ )
        {
            dp[i,0] = dp[i-1,1] + nums[i];              // 偷
            dp[i,1] = Math.Max( dp[i-1,0], dp[i-1,1] ); // 不偷
        }
        return Math.Max( dp[len-1,0], dp[len-1,1] );


    }
    

}





