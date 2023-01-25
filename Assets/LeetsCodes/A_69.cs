using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    0069: x 的平方根 


    二分查找
    
*/

public class A_69
{



    public static int MySqrt(int x) 
    {
        if( x==0 )
        {
            return 0;
        }

        // 因为涉及乘法, 所以要用 long, 是个坑;
        long l = 0;
        long r = x;

        while( l<=r )
        {
            if( l==r )
            {
                long v= l*l;
                // 返回值用哪个, 是个坑
                return (int)((x==v) ? l :
                            (x<v) ? l-1 : l);
            }

            long mid = l + (r-l)/2;
            long midVal = mid*mid;

            if( (long)x > midVal )
            {
                l = mid+1; // 坚决剔除
            }
            else if( (long)x < midVal ) 
            {
                r = mid;
            }
            else 
            {
                return (int)mid;
            }
        }
        // 永远不会运行到此处
        return 0;
    }





    public static void Main() 
    {
        int[] nums1 = new int[]{  };

        //2147395599

        var ret = MySqrt( 2147395599 );
        

        //var ret = SearchInsert_2( nums1, -1 ); //  此时会出错...

        Debug.Log( "ret = " + ret );



        // foreach( var e in nums1 ) 
        // {
        //     Debug.Log(e);
        // }


    }

}





