using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


using TypeA;


/*
    0455: 分发饼干

    
*/

public class A_455
{

    // g: 各小孩满足值 
    // s: 各苹果值
    public static int FindContentChildren(int[] g, int[] s) 
    {
        Array.Sort(g);
        Array.Sort(s);

        int l=0;
        int r=0;
        int sum = 0;

        for( ; l<g.Length; l++ )// 遍历每个小孩
        {
            while( r<s.Length && s[r]<g[l] )
            {
                r++;
            }
            if( r>=s.Length )
            {
                break;
            }
            sum++;
            r++;
        }

        return sum;

    }


    public static void Main() 
    {
        

    }


}









