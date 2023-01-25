using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    0042: 接雨水


    来回遍历法:
    从左往右走一趟, 记录每一格的 历史最高值;
    从右往左走一趟, 记录每一格的 历史最高值;
    取这两组值的 最小值;
    然后拿着这个值, 减去每个格子的底面高度, 得到每个格子的雨水量;
*/

public class A_42
{



    public static int Trap(int[] height) 
    {

        int len = height.Length;

        int[] maxHeight = new int[len];

        int h = 0;
        for( int i=0; i<len; i++ )// 从左往右
        {
            h = Math.Max( h, height[i] );
            maxHeight[i] = h;
        }

        h = 0;
        for( int i=len-1; i>=0; i-- )// 从右往左
        {
            h = Math.Max( h, height[i] );
            maxHeight[i] = Math.Min( maxHeight[i], h ); // 两趟遍历的最小值
        }

        int sum = 0;
        for( int i=0; i<len; i++ )
        {
            sum += maxHeight[i] - height[i];
        }
        return sum;
    }





    public static void Main() 
    {
        int[] nums1 = new int[]{  };

        


    }

}





