using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using A;


/*
    0055: 跳跃游戏


    动态规划 
*/

public class A_0055
{

    
    public static bool CanJump(int[] nums) 
    {
        int len = nums.Length;
        if( len==1 )
        {
            return true;
        }

        int[] dp = new int[len]; // 可被优化成 两个值;
        dp[0] = 0;

        for( int i=1; i<len; i++ )
        {
            dp[i] = Math.Max( nums[i-1], dp[i-1] ) - 1;

            // 如果某一格永远到不了, 那意味着后面的所有格都到不了
            if( dp[i] < 0 )
            {
                return false;
            }
        }
        return dp[len-1] >= 0;




    }

}





