using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;



/*
    
    1004. 最大连续1的个数 III
    

    滑动窗口

    从头部开始滑动一个窗口, 里面记录了 0的个数, 
    每次尝试固定左侧增加右侧, 如果合法, 则这个长度将被永久保持
    如果不合法, 就维持现有长度右移一位;

*/
public class A_1004
{

    // 边界绑定有点麻烦...

    // 参考答案中, r先滑动, 当 zero数量超标时, l单独滑动, 且有可能滑到 r右边去;
    // 以此来实现 极限情况: {0,0,0,0,} k=0 中, 返回值是 0 的情况...
    
    public int LongestOnes(int[] nums, int k) 
    {
        


        return 0;
    }



    
     

    public static void Main() 
    {
        var instance = new A_1004();

        int[] nums = new int[]{
            1,1,0,1,0,0
            //1,1,1,0,0,0,1,1,1,1,0
        };


        var ret =   instance.LongestOnes( nums, 1 );
        Debug.Log( "ret = " + ret );
        
    
    }




}






