using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    0088: 合并两个有序数组

    ---
    最简单的方法: 先把 nums1 的前 m 个元素复制到一个 辅助数组中,
    然后把 nums1 当作最终数组 来处理;

    ---
    倒叙
*/


public class A_0088
{

    // 倒着排序, 从最后一对开始, 挑 值大的拿;
    //
    // 很巧妙的题, 一些边界判断 都可以被隐藏在主代码中
    public static void Merge(int[] nums1, int m, int[] nums2, int n) 
    {

        int l = m-1;
        int r = n-1;
        int i = nums1.Length-1;

        while( l>=0 && r>=0 )
        {
            nums1[i--] = (nums1[l] >= nums2[r]) ? nums1[l--] : nums2[r--];
        }
        // 现在, 至少有一条已经用光了;
        if( r>=0 )
        {
            while( i>=0 )
            {
                nums1[i--] = nums2[r--];
            }
        }
    }



    public static void Main() 
    {
        int[] nums1 = new int[]{ 1,3,5,0,0,0,0 };
        int[] nums2 = new int[]{ 2,2,4,6 };

        Merge( nums1,3, nums2, 4 );

        foreach( var e in nums1 ) 
        {
            Debug.Log(e);
        }


    }

}





