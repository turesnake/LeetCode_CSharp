using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;



/*
    1876. 长度为三且各字符不同的子字符串
 
    滑动窗口 固定
*/
public class A_1984
{

    
    public int MinimumDifference( int[] nums, int k )
    {

        Array.Sort(nums); // 升序

        int len = nums.Length;
        int ret = int.MaxValue;
        int l=0; 
        int r= l+k-1; // 窗口最后一个元素

        for( ; r<len; l++,r++ ) 
        {
            ret = Math.Min( ret, nums[r]-nums[l] );
        }

        return ret;
    }
    

    
     

    public static void Main() 
    {
        var instance = new A_1984();

        
        
    
    }




}






