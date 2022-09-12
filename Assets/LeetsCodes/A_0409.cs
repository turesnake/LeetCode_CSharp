using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


using TypeA;


/*
    0409: 最长回文串

    
*/

public class A_0409
{

    
    public static int LongestPalindrome( string s ) 
    {
        // 大写在前,小写在后
        int[] ary = new int[52];

        foreach( char c in s )
        {
            int ic = (int)c;
            ic = (ic>=97) ? ic-97+26 : ic-65;

            ary[ic]++;
        }

        bool isFindSingle = false; 
        int sum = 0;

        foreach( var e in ary )
        {
            if( !isFindSingle )
            {
                isFindSingle = e%2==1;
            }
            sum += (e/2)*2;
        }

        sum = isFindSingle ? sum+1 : sum;
        return sum;
    }


    public static void Main() 
    {
        

    }


}









