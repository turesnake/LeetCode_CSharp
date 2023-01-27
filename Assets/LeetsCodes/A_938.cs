using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeC;


/*
    938. 二叉搜索树的范围和



    中序遍历  left - root - right

*/

// 递归版
public class A_938
{

    

    public int RangeSumBST( TreeNode root, int low, int high )
    {

        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode ptr = root;
        int sum = 0;

        bool isInRange = false;

        while( ptr!=null || stack.Count>0 )
        {
            if(ptr!=null)
            {
                stack.Push(ptr);
                ptr = ptr.left;
            }
            else 
            {
                TreeNode q = stack.Pop();

                if( q.val == low || isInRange == true )
                {
                    isInRange = true;
                    sum += q.val;
                }
                if( q.val == high )
                {
                    break;
                }
                ptr = q.right;
            }
        }

        return sum;
    }



    public static void Main() 
    {
        var instance = new A_938();

        

        
    
    }
    
}





