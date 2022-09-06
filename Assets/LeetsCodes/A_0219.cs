using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using A;


/*
    0219: 存在重复元素 II


    
*/

public class A_0219
{

    // 感觉就是对 map 的灵活使用
    public static bool ContainsNearbyDuplicate( int[] nums, int k ) 
    {
        
        Dictionary<int,int> dic = new Dictionary<int, int>();

        for( int i=0; i<nums.Length; i++ )
        {
            int val = nums[i];
            if( dic.TryAdd( val, i) == false ) // 要么新添加
            {
                if( i-dic[val] <= k )
                {
                    return true;
                }
                dic[val] = i; // 要么更新为最右值
            }
        }
        return false;
    }

}





