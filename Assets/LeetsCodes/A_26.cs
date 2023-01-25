using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    0026: 删除有序数组中的重复项
*/


public class A_26
{

    // 双指针法, 一个主指针, 一个辅指针
    public static int RemoveDuplicates( int[] nums )
    {

        // if( nums.Length==1 ) 
        // {
        //     return 1;
        // }

        // l 需要停留在第一个出现异常的位置, 但这个异常不一定能被 r 处理掉
        // 设计上, l 一定会停留在 第一个出现异常的位置, 这个位置甚至可以是 尾后;
        int l = 1; 
        // r 是一个辅助指针, 用来在 l后方搜索第一个能用的 替换元素; 很可能找不到能替换的元素;
        int r = 0;

        while( l<nums.Length && r<nums.Length ) 
        {
            
            while( l<nums.Length && nums[l] > nums[l-1] ) 
            {
                l++;
            }

            if( l>=nums.Length )
            {
                break;
            }

            r = Math.Max( l+1, r);
            while( r<nums.Length && nums[r] <= nums[l] ) 
            {
                r++;
            }

            if( r<nums.Length )
            {
                (nums[l], nums[r]) = (nums[r], nums[l]); // swap
            }
        }

        // 因为现在 [l-1] 就是处理后数组的最后一个元素, 元素个数恰好等于 l
        return l;
    }


    public static void Main() 
    {
        int[] nums = new int[]{ -3,-3,-2,-1,-1,0,0,0,0,0 };

        int rnum = RemoveDuplicates( nums );

        Debug.Log( "ret num = " + rnum );

        foreach( var e in nums ) 
        {
            Debug.Log(e);
        }


    }

}





