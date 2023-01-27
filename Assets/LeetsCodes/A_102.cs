using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeC;


/*
    102. 二叉树的层序遍历


    使用 前序遍历 来走
*/

// 递归版
public class A_102
{

    IList<IList<int>> rets = new List<IList<int>>();

    void K( TreeNode root, int deep ) 
    {
        if( root == null )
        {
            return;
        }

        if( rets.Count < deep + 1 )
        {
            rets.Add( new List<int>() );
        }

        rets[deep].Add( root.val );

        K( root.left, deep+1 );
        K( root.right, deep+1 );
    }


    
    public IList<IList<int>> LevelOrder( TreeNode root ) 
    {
        K( root, 0 );
        return rets;
    }




    public static void Main() 
    {
        var instance = new A_102();

        

        
    
    }
    
}





