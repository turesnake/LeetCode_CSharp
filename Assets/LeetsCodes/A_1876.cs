using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;



/*
    1876. 长度为三且各字符不同的子字符串
 
    滑动窗口 固定
*/
public class A_1876
{

    

    public int CountGoodSubstrings( string s ) 
    {
        int len = s.Length;
        if( len < 3 )
        {
            return 0;
        }
        //---:

        int ret = 0;
        int l = 0; // 从第二个元素开始
        int r = l+3-1;

        for( ; r<s.Length; l++,r++ ) 
        {
            char a = s[l];
            char b = s[l+1];
            char c = s[l+2];

            if( a!=b && b!= c && a!=c ) 
            {
                ret++;
            }
        }
        return ret;
    }

    
     

    public static void Main() 
    {
        var instance = new A_1876();

        
        
    
    }




}






