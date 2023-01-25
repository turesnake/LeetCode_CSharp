using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


using TypeA;


/*
    0136: 只出现一次的数字

    使用 异或 来相加所有元素, 如果一个元素出现两次, 会被抵消;
*/

public class A_136
{

    public static int SingleNumber(int[] nums) 
    {
        int sum = 0;
        foreach( var e in nums )
        {
            sum = sum^e;
        }
        return sum;
    }


}









