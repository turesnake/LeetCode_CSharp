using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeC;


/*
    144. 二叉树的前序遍历

    root - 左 - 右

*/

// 递归
public class A_144
{
    IList<int> ret = new List<int>();

    void K(TreeNode root)
    {
        if( root == null ) 
        {
            return;
        }
        ret.Add(root.val);
        K(root.left);
        K(root.right);
    }


    public IList<int> PreorderTraversal( TreeNode root ) 
    {
        K(root);
        return ret;
    }
    
}


// 遍历法
// 前序 和 后续的 遍历法 都没有 中序的复杂, 不要想得复杂了...
// 
public class A_144_2
{
    public IList<int> PreorderTraversal(TreeNode root) 
    {
        IList<int> ret = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push( root );

        while( stack.Count > 0 ) 
        {
            TreeNode p = stack.Pop();
            if( p != null ) // 为了规避 root == null 这个问题, 也可在外部打补丁
            {
                ret.Add(p.val);
            
                // 利用栈结构, 倒着压入栈, 先右后左
                if( p.right != null )
                {
                    stack.Push( p.right );
                }
                if( p.left != null )
                {
                    stack.Push( p.left );
                }
            }
        }

        return ret;
    }
    
}




