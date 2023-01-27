using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeC;


/*
    145. 二叉树的后序遍历

    左 - 右 - root

*/

// 递归
public class A_145
{
    IList<int> ret = new List<int>();

    void K(TreeNode root)
    {
        if( root == null ) 
        {
            return;
        }
        K(root.left);
        K(root.right);
        ret.Add(root.val);
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
public class A_145_2
{
    public IList<int> PreorderTraversal(TreeNode root) 
    {
        List<int> ret = new List<int>(); // 此处不能用 Ilist 了, 否则无法调用 Reverse()
        if( root == null ) 
        {
            return ret;
        }

        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push( root );

        while( stack.Count > 0 ) 
        {
            TreeNode p = stack.Pop();
            
            ret.Add(p.val);
        
            // 倒叙 叠 倒叙
            if( p.left != null )
            {
                stack.Push( p.left );
            }
            if( p.right != null )
            {
                stack.Push( p.right );
            }
        }
        ret.Reverse();
        return ret;
    }
    
}




