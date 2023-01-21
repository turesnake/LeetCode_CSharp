using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    1791: 找出星型图的中心节点


    图
*/
public class A_1791
{

    /*
        edges 至少有2个元素,
        最简做法, 从 [0], [1] 中找出相同元素即可
    */
    
    public static int FindCenter(int[][] edges) 
    {
        var a = edges[0];
        var b = edges[1];
        if( a[0] == b[0] || a[1] == b[0] ) 
        {
            return b[0];
        }
        else 
        {
            return b[1];
        }

    }


    
    
}

