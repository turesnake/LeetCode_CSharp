using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeC;


/*
    331. 验证二叉树的前序序列化


    "9,3,4,#,#,1,#,#,2,#,6,#,#"

    思路就是从叶子节点开始向上消除; 
    每找到连续的两个 #, 就能与前面一个 数字 三值合并为一个 #;

    然后不停地往上消;

    可以倒序遍历 数字来实现;

*/

// 递归版
public class A_331
{



    public bool IsValidSerialization( string preorder )
    {

        List<string> charsA = new List<string>( preorder.Split(',') );
        List<string> charsB = new List<string>();


        while( true )
        {
            if( charsA.Count == 1 && charsA[0] == "#" )
            {
                break;
            }

            for( int i=charsA.Count-1; i>=0; ) //倒叙, 一次可访问 3 个元素
            {
                if( i>=2 && charsA[i]=="#" && charsA[i-1]=="#" && charsA[i-2]!="#" )
                {
                    charsB.Add("#");
                    i -= 3;
                }
                else 
                {
                    charsB.Add( charsA[i] );
                    i--;
                }
            }
            charsB.Reverse();

            string log = "charsB: ";
            foreach( var e in charsB ) 
            {
                log += e + ", ";
            }
            Debug.Log( log );

            if( charsB.Count == charsA.Count )
            {
                return false;
            }

            (charsA, charsB) = (charsB, charsA); // swap
            charsB.Clear();
        }

        return true;
    }


    public static void Main() 
    {
        var instance = new A_331();

        //string s = "9,3,4,#,#,1,#,#,2,#,6,#,#";
        string s = "9,#,#,1";
        
        bool ret = instance.IsValidSerialization(s);
        
        Debug.Log( "ret = " + ret );
    
    }
    
}





