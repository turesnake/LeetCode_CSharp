using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeC;


/*
    979. 在二叉树中分配硬币




*/


public class A_979
{
    class Data 
    {
        public int nodeNums;
        public int coinNums;
        public Data( int nodeNums_, int coinNums_ )
        {
            nodeNums = nodeNums_;
            coinNums = coinNums_;
        }
    }

    int sum = 0;

    Data K( TreeNode root )
    {
        if( root == null ) 
        {
            return new Data( 0, 0 );
        }

        var lData = K( root.left );
        var rData = K( root.right );

        var data = new Data(
            1        + lData.nodeNums + rData.nodeNums,
            root.val + lData.coinNums + rData.coinNums
        );

        sum += Math.Abs(data.coinNums - data.nodeNums);
        return data;
    }
    
    public int DistributeCoins( TreeNode root ) 
    {
        K( root );
        return sum;
    }



    public static void Main() 
    {
        var instance = new A_979();

        

        
    
    }
    
}





