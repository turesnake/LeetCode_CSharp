using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    0031: 下一个排列
*/


public class A_0031
{

    public static void NextPermutation( int[] nums ) 
    {
        int len = nums.Length;
        if( len==1 )
        {
            return;
        }
        if( len==2 )
        {
            (nums[0],nums[1]) = (nums[1],nums[0]);
            return;
        }
        // 现在, [l], [l+1], [l+2] 保证都是有元素的

        int lastL = -1; // 最后一对升序对的 左侧元素 idx;
        for( int i=0; i<len-1; i++ ) 
        {
            if( nums[i] < nums[i+1] )
            {
                lastL = i;
            }
        }

        if( lastL == -1 ) // 没找到任何 升序对, 说明原数组为 全逆序
        {
            Array.Sort( nums ); // 全升序
            return;
        }

        if( lastL+1 == len-1 ) // 最后的升序对 是 最后两个元素
        {
            (nums[lastL],nums[lastL+1]) = (nums[lastL+1],nums[lastL]);
            return;
        }

        // 在 [lastL+1. end] 区间中找出最小的值, 和 [lastL] 交换, 然后将后方区间做 升序排序;
        int minIdx = lastL + 1;
        for( int i=minIdx+1; i<len; i++ )
        {
            if( nums[i] < nums[minIdx] && nums[i] > nums[lastL] )
            {
                minIdx = i;
            }
        }

        (nums[lastL], nums[minIdx]) = (nums[minIdx], nums[lastL]); // swap
        Array.Sort( nums, lastL+1, len-lastL-1 );

    }

    public static void Main() 
    {
        int[] nums = new int[]{ 5,4,7,5,3,2 };

        NextPermutation( nums );

        foreach( var e in nums ) 
        {
            Debug.Log(e);
        }


    }

}





