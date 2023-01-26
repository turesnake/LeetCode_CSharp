using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;



/*
    
    1475. 商品折扣后的最终价格
    

    单调栈: 递增栈
    

    

*/
public class A_1475
{

    /*
        小陷阱, 这个题没说元素不重复, 所以不能用 dic 来存 idx; 

        解法就是在 stack 中直接存储 idx
    */
    public int[] FinalPrices( int[] prices ) 
    {
        int len = prices.Length;

        int[] ret = new int[len];
        prices.CopyTo( ret, 0 );

        Stack<int> stack = new Stack<int>(); // 存储的是元素的 idx;
        stack.Push( 0 );

        for( int i=1; i<len; i++ )
        {
            int e = prices[i];
            while( stack.Count > 0 && prices[stack.Peek()] >= e ) // 将栈中大元素逐个取出处理
            {
                int j = stack.Pop(); // idx
                ret[j] = prices[j] - e;
            }
            stack.Push( i );
        }
        return ret;
    }

    
     

    public static void Main() 
    {
        var instance = new A_1475();

        

        
    
    }




}






