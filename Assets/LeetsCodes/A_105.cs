using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeC;


/*
    105. 从前序与中序遍历序列构造二叉树


    

*/

// 递归版
public class A_105
{
    int[] _preorder;
    Dictionary<int,int> inDic = new Dictionary<int, int>();

    TreeNode K( int preorderIdx, int inorderIdx, int len )
    {
        if( len == 0 )
        {
            return null;
        }

        int parentVal = _preorder[preorderIdx];
        int parentIdx = inDic[parentVal];

        int leftLen = parentIdx - inorderIdx;
        int rightLen = len - 1 - leftLen;

        TreeNode node = new TreeNode(parentVal);
        node.left  = K( preorderIdx + 1,            inorderIdx,                 leftLen );
        node.right = K( preorderIdx + 1 + leftLen,  inorderIdx + leftLen + 1,   rightLen );
        return node;
    }
    
    

    public TreeNode BuildTree( int[] preorder, int[] inorder ) 
    {
        _preorder = preorder;
        int len = preorder.Length;

        for( int i=0; i<len; i++ )
        {
            inDic.Add( inorder[i], i );
        }

        return K( 0, 0, len );
    }




    public static void Main() 
    {
        var instance = new A_105();

        

        
    
    }
    
}





