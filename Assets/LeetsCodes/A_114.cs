using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeC;


/*
    114. 二叉树展开为链表


    先序遍历

*/

// 递归版
public class A_114
{

    

    public void Flatten(TreeNode root) 
    {
        if( root == null )
        {
            return;
        }

        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push( root );

        TreeNode parent = new TreeNode();
        TreeNode tmp = parent;

        while( stack.Count > 0 ) 
        {
            TreeNode q = stack.Pop();

            var l = q.left;
            var r = q.right;

            q.left = null;
            tmp.right = q;
            tmp = tmp.right;

            // 倒叙插入:
            if( r != null )
            {
                stack.Push( r );
            }
            if( l != null )
            {
                stack.Push( l );
            }
        }

        root = parent.right;
    }



    public static void Main() 
    {
        var instance = new A_114();

        

        
    
    }
    
}





