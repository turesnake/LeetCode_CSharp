using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using A;


/*
    0011: 盛最多水的容器

    双指针法;
*/

public class A_0011
{



    public static int MaxArea(int[] height) 
    {
        int maxVal = 0;

        int l=0;
        int r = height.Length-1;

        while( l<r ) 
        {
            if( height[l] <= height[r] )
            {
                maxVal = Math.Max( maxVal, (r-l)*height[l++] );
            }
            else 
            {
                maxVal = Math.Max( maxVal, (r-l)*height[r--] );
            }
        }
        return maxVal;
    }





    public static void Main() 
    {
        int[] nums1 = new int[]{  };

        //2147395599

        //var ret = MySqrt( 2147395599 );
        

        //var ret = SearchInsert_2( nums1, -1 ); //  此时会出错...

        //Debug.Log( "ret = " + ret );



        // foreach( var e in nums1 ) 
        // {
        //     Debug.Log(e);
        // }


    }

}





