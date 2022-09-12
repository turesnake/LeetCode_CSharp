using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


using TypeA;


/*
    0561: 数组拆分

    
*/

public class A_0561
{

    public int ArrayPairSum(int[] nums) 
    {
        Array.Sort(nums);
        int sum = 0;

        for( int i=0; i<nums.Length; i+=2 )
        {
            sum += nums[i];
        }
        return sum;



    }


    public static void Main() 
    {
        

    }


}









