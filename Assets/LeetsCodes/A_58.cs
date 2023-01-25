using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


using TypeA;


/*
    0058: 最后一个单词的长度

    
*/

public class A_58
{

    // 倒叙遍历;
    public static int LengthOfLastWord(string s) 
    {

        int len = s.Length;
        int i = len-1;
        for( ; i>=0 && s[i]==' '; i-- )
        {}
        // 现在, i 指向 尾字符;
        int j=i;

        for( ; j>=0 && s[j]!=' '; j-- )
        {}
        // 现在, j 要么指向 -1, 要么指向 第一个空格
        //Debug.Log( "i = " + i + "; j = " + j );
        return i-j;

    }


    public static void Main() 
    {
        Debug.Log( LengthOfLastWord( " aaa " ) );
        Debug.Log( LengthOfLastWord( " aaa" ) );
        Debug.Log( LengthOfLastWord( "aaa " ) );
        Debug.Log( LengthOfLastWord( "aaa" ) );

    }


}









