using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using A;


/*
    0066: 加一
*/


public class A_0066
{

    public int[] PlusOne( int[] digits ) 
    {
        List<int> ret = new List<int>( digits.Length+1 );

        int i = digits.Length-1;
        int quot = 1; // 因为要加1

        while( i>=0 || quot>0 ) 
        {

            int v = i>=0 ? digits[i] : 0;

            int mod  = (v + quot) % 10;
            quot     = (v + quot) / 10;

            ret.Add( mod );
            i--;
        }

        ret.Reverse();
        return ret.ToArray();
    }

}





