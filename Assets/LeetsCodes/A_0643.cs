using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    0643: 子数组最大平均数 I


    滑动窗口
*/

public class A_0643
{

    // 因为窗口长度固定为 k, 所以几乎不需要什么技法
    public static double FindMaxAverage(int[] nums, int k) 
    {
        int len = nums.Length;

        int sum = 0;
        for( int i=0; i<k; i++ )
        {
            sum += nums[i];
        }
        int maxSum = sum;

        for( int i=k; i<len; i++ )
        {
            sum = sum - nums[i-k] + nums[i];
            maxSum = Math.Max( maxSum, sum );
        }
        return (double)maxSum/(double)k; // 若使用 float, 有时无法满足 测试的精度要求


    }

}





