using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

/*
    0014: 最长公共前缀
*/

/*
    从头开始构造一个树, 每个字符存储在一层;
    这个方法还是想复杂了...
*/
public class A_0014
{
    public class Node 
    {
        public Dictionary<char,Node> dic = new Dictionary<char, Node>();
    }

    // 返回 没有分叉的那一层的 idx
    static int record(Node node, string str, int idx )
    {
        if( idx >= str.Length  ) 
        {
            return idx-1;
        }

        char c = str[idx];
        if( node.dic.ContainsKey(c) == false )
        {
            node.dic.Add( c, new Node() );
        }

        // 若发现本层有 两个及以上元素, 直接返回
        if( node.dic.Count > 1 )
        {
            return idx-1;
        }
        
        return record( node.dic[c], str, idx+1 );
    }

    public static string LongestCommonPrefix_1(string[] strs) 
    {
        Node rootNode = new Node();

        int minIdx = 99999;
        foreach( var e in strs ) 
        {
            if( e == "" )
            {
                return "";
            }
            int idx = record( rootNode, e, 0 );
            minIdx = Math.Min( minIdx, idx );
        }

        return strs[0].Substring( 0, minIdx+1 );
    }
}




/*

*/
public class A_0014_B
{
    static string ans = "";
    static int minIdx = 9999;

    static void Work( string str )
    {
        int i=0;
        for( ; i<=minIdx && i<str.Length; i++ ) 
        {
            if( ans[i] != str[i] )
            {
                //return i-1;
            }
        }

        //return Math.Min(  );

        //  未完...
    }
    

    public static string LongestCommonPrefix_1(string[] strs) 
    {
        
        if( strs.Length==0 )
        {
            return "";
        }

        ans = strs[0];
        minIdx = ans.Length-1;

        for( int i=1; i<strs.Length; i++ ) // 跳过第一个
        {

            if( strs[i] == "" || minIdx==-1 )
            {
                return "";
            }
            Work( strs[i] );
        }

        return strs[0].Substring( 0, minIdx+1 );
    }
}




