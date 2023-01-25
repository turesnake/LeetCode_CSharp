using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    0027: 移除元素
*/


public class A_27
{

    // 双指针法
    // 边界不容易处理干净, 进而之: 若一个数组内都是 目标值, 容易出错;
    // 所有 while 判断符号要用 <=
    public static int RemoveElement( int[] nums, int val) 
    {

        int l = 0;
        int r = nums.Length-1;
        while( l <= r ) // 务必要为 <=; 
        {

            if( nums[r] == val )
            {
                r--;
                continue;
            }

            if( nums[l] != val )
            {
                l++;
                continue;
            }

            ( nums[l], nums[r] ) = ( nums[r], nums[l] ); // use tuple to swap
    
        }
        return r+1;
    }



    public static void Main() 
    {
        int[] nums = new int[]{ 1,2,3 };

        RemoveElement( nums, 0 );

        foreach( var e in nums ) 
        {
            Debug.Log(e);
        }


    }

}





