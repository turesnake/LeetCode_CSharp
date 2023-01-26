using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;



/*
    
    496. 下一个更大元素 I
    

    单调栈: 递减栈
    

*/
public class A_496
{

    

    public int[] NextGreaterElement( int[] nums1, int[] nums2 ) 
    {

        Dictionary<int,int> ids = new Dictionary<int, int>();
        for( int i=0; i<nums1.Length; i++ ) 
        {
            ids.Add( nums1[i], i );
        }

        int[] ret = new int[nums1.Length];
        Array.Fill( ret, -1 );

        Stack<int> stack = new Stack<int>(); // 单调栈
        stack.Push( nums2[0] );

        int count = 0;


        for( int i=1; i<nums2.Length; i++ ) 
        {
            var e = nums2[i];

            while( stack.Count > 0 && e > stack.Peek() ) 
            {
                int b = stack.Pop();

                if( ids.ContainsKey(b) )
                {
                    ret[ids[b]] = e;
                    count++;
                    if( count == nums1.Length )
                    {
                        return ret;
                    }
                }
            }
            stack.Push( e );
        }
        return ret;
    }
    
     

    public static void Main() 
    {
        var instance = new A_496();

        

        
    
    }




}






