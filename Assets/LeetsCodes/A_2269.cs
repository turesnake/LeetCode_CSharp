using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;



/*
    2269. 找到一个数字的 K 美丽值
    

*/
public class A_2269
{

    
    // 借用 string 来处理一串 字符串
    public int DivisorSubstrings_1( int num, int k) 
    {
        string numStr = num.ToString();

        int l=0;
        int r = l + k - 1; // 尾元素

        int ret = 0;

        for( ; r < numStr.Length; l++,r++ ) 
        {
            string aStr = new string( numStr.ToCharArray(), l, k );
            Int32.TryParse( aStr, out int a );
            if( a!=0 && (num%a) == 0 ) 
            {
                ret++;
            }
        }

        return ret;
    }


    // 数组版
    public int DivisorSubstrings_2( int num, int k) 
    {
        // 准备好数组:
        int tmpNum = num;
        List<int> numList = new List<int>();
        while( tmpNum > 0 ) 
        {
            numList.Add( tmpNum % 10 );
            tmpNum /= 10;
        }
        numList.Reverse();

        int ret = 0;
        int l=0;
        int r=l+k-1;

        for( ; r<numList.Count; l++,r++ )
        {
            int a = 0;
            for( int i=l; i<=r; i++ )
            {
                a = a * 10 + numList[i];
            }
            //Debug.Log( a );
            if( a!=0 && (num%a)==0 ) 
            {
                ret++;
            }
        }
        return ret;
    }

    
     

    public static void Main() 
    {
        var instance = new A_2269();

            instance.DivisorSubstrings_2( 2403, 2 );
        
    
    }




}






