using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    0121: 买卖股票的最佳时机


    -- 遍历法
    -- 哨兵 + 单调栈
*/

public class A_121__
{

    // 非动态规划解法,   感觉是一种类似 最大盛水题 的遍历法...
    public static int MaxProfit_1(int[] prices) 
    {
        int len = prices.Length;
        if(len==1)
        {   
            return 0;
        }

        int minPrice = prices[0];
        int maxEarn = 0;

        for( int i=1; i<len; i++ )
        {
            maxEarn = Math.Max( maxEarn, prices[i] - minPrice );
            minPrice = Math.Min( minPrice, prices[i] );
        }
        return maxEarn;


    }


    // 哨兵 + 单调栈
    public static int MaxProfit_2(int[] prices) 
    {
        int len = prices.Length;
        if( len==1 )
        {
            return 0;
        }

        





        return 0;
    }
    
    

}





