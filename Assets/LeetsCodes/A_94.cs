using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeC;


/*
    94. 二叉树的中序遍历
 
    
    左 - root - 右

*/

// 递归
public class A_94
{
    IList<int> ret = new List<int>();

    void K( TreeNode root ) 
    {
        if( root == null ) 
        {
            return;
        }
        K( root.left );
        ret.Add( root.val );
        K( root.right );
    }
    
    public IList<int> InorderTraversal( TreeNode root ) 
    {
        K(root);
        return ret;
    }
}


// 遍历法
// 目前这种写法 比较啰嗦, 需要 3 个 while, 其实可以更简洁, 见 下方
public class A_94_2
{
    public IList<int> InorderTraversal( TreeNode root ) 
    {
        IList<int> ret = new List<int>();

        Stack<TreeNode> stack = new Stack<TreeNode>();

        TreeNode q = root;
        while( q != null ) 
        {
            stack.Push(q);
            q = q.left;
        }

        while( stack.Count > 0 )
        {
            TreeNode p = stack.Peek();

            ret.Add( p.val );
            stack.Pop();

            q = p.right;
            while( q != null ) 
            {
                stack.Push(q);
                q = q.left;
            }
        }

        return ret;
    }
}


// 遍历, 外部指针法
// 其实核心难点在于, 不能在把 parent 的所有 left 都入栈后, 未来再处理一次这个 parent 
// 解法就是依靠一个 循环之外的 指针 ptr, 它若指向一个 有效节点, 则会进入不断寻找 left 的过程, 直到自己为 null
// 它若位于 null 值, 则进入到处理 stack 元素的流程...
public class A_94_3
{
    public IList<int> InorderTraversal( TreeNode root ) 
    {
        IList<int> ret = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode ptr = root;

        while( ptr != null || stack.Count > 0 )
        {
            if( ptr != null )
            {
                // 不断寻找 left 的模式:
                stack.Push( ptr );
                ptr = ptr.left;
            }
            else 
            {
                // 处理 stack 元素的模式:
                // 现在, ptr 指向某个值为 null 的 left (或 right)
                TreeNode q = stack.Pop();
                ret.Add( q.val );
                ptr = q.right;
            }
        }

        return ret;
    }
}





