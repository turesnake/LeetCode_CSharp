using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeC;


/*
    897. 递增顺序搜索树


    

*/

// 递归版
public class A_897
{
    
    public TreeNode IncreasingBST( TreeNode root ) 
    {

        Stack<TreeNode> stack = new Stack<TreeNode>();

        TreeNode parent = new TreeNode(-99);// 只使用它的 right
        TreeNode tmp = parent; // 维护链表的增长
        TreeNode ptr = root;

        while( ptr != null || stack.Count > 0 ) 
        {
            if( ptr != null )
            {
                stack.Push(ptr);
                ptr = ptr.left;
            }
            else
            {
                // 现在 p 指向某个 null 的 left 或 right;
                TreeNode q = stack.Pop();
                q.left = null;
                tmp.right = q;
                tmp = q;
                //---:
                ptr = q.right;
            }
        }

        return parent.right;
    }


    public static void Main() 
    {
        var instance = new A_897();

        

        
    
    }
    
}





