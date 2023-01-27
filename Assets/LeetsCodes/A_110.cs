using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeC;


/*
  110. 平衡二叉树  

    
    判断每个节点的 左右树的 深度值;
*/

// 递归版
public class A_110
{

    bool isIllegal = false; // 默认有效


    // ret: 若得到答案, 返回 true
    int K( TreeNode root, int deep )
    {
        if( root == null )
        {
            return deep;
        }
        int leftDeep  = K( root.left,  deep+1 );
        int rightDeep = K( root.right, deep+1 );

        if( Math.Abs(leftDeep-rightDeep) > 1 )
        {
            isIllegal |= true;
        }
        return Math.Max( leftDeep, rightDeep );
    }
    
    

    public bool IsBalanced( TreeNode root )
    {
        K( root, 0 );
        return !isIllegal;
    }





    public static void Main() 
    {
        var instance = new A_110();

        

        
    
    }
    
}





