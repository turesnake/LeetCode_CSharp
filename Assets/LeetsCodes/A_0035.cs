using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    0035: 搜索插入位置

    二分查找

    
*/

// 实质就是 查找 大于等于 tgt 的 最小值（左区间）


public class A_0035
{

    
    // ============================
    //           递归版
    static int recu( int[] nums, int target, int l, int r ) 
    {
        if( l==r )
        {
            return target<=nums[l] ? l : l+1; // 值相同时插入左边, 仅仅是本题的规定;
        }
        int mid = l + (r-l)/2;
        int midVal = nums[mid];

        if( target > midVal )// 坚决剔除
        {
            return recu( nums, target, mid+1, r );
        }
        else if( target < midVal ) 
        {
            return recu( nums, target, l, mid );
        }
        else { // ==
            return mid;
        }
    }
    public static int SearchInsert(int[] nums, int target) 
    {
        if( nums.Length==0 )
        {
            return 0;
        }
        int len = nums.Length;
        int l = 0;
        int r = len-1;
        return recu( nums, target, l, r );
    }


    // ============================
    //          循环版
    public static int SearchInsert_2(int[] nums, int target) 
    {
        int len = nums.Length;
        int l = 0;
        int r = len-1;

        while( l<=r ) // 意义有限, 按照本算法, 除非 nums 无元素, 否则 l<=r 永远成立;
        {
            if( l==r )
            {
                // 两值相等也是可能的, 此时直接返回 l;
                return target<=nums[l] ? l : l+1;
            }
            int mid = l+(r-l)/2;
            int midVal = nums[mid];
            if( midVal < target )
            {
                l = mid+1; // 坚决剔除
            }
            else if( midVal > target ) 
            {   
                r = mid;
            }
            else 
            {
                return mid;
            }
        }

        // 只有当 nums 无元素, 才会运行至此;
        return 0;
    }








    public static void Main() 
    {
        int[] nums1 = new int[]{  };
        

        var ret = SearchInsert_2( nums1, -1 ); //  此时会出错...

        Debug.Log( "ret = " + ret );



        // foreach( var e in nums1 ) 
        // {
        //     Debug.Log(e);
        // }


    }

}





