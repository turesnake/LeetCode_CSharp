using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


using TypeA;


/*
    0605: 种花问题

    
*/

public class A_605
{

    public static bool CanPlaceFlowers( int[] flowerbed, int n ) 
    {
        int len = flowerbed.Length;
        if( len == 1 )
        {
            return (1-flowerbed[0]) >= n;
        } 

        // ----- 将所有 临1的0, 改为 2: ------
        // 单独处理 首尾两个元素
        if( flowerbed[0] == 0 && flowerbed[1] == 1 )
        {
            flowerbed[0] = 2;
        }
        if( flowerbed[len-1] == 0 && flowerbed[len-2] == 1 )
        {
            flowerbed[len-1] = 2;
        }

        for( int i=1; i<len-1; i++ )
        {
            if( flowerbed[i]==0 && ( flowerbed[i-1]==1 || flowerbed[i+1]==1 ) )
            {
                flowerbed[i] = 2;
            }
        }

        // ------ 统计连续0;
        int sum = 0;
        int zeroNum = 0;

        for( int i=0; i<len; i++ )
        {
            if( flowerbed[i] == 0 )
            {
                zeroNum++;

                // 清算:
                if( i==len-1 || flowerbed[i+1]!=0 )
                {
                    Debug.Log( zeroNum + ": " + ((zeroNum%2==0) ? zeroNum/2 : zeroNum/2 + 1) );
                    sum += (zeroNum%2==0) ? zeroNum/2 : zeroNum/2 + 1;
                }
            }
            else
            {
                if( zeroNum > 0 )
                {
                    zeroNum = 0;
                }
            }
        }
        return sum>=n;


        


    }


    public static void Main() 
    {
        int[] ary = { 0,0,1,0,1 };

        bool ret = CanPlaceFlowers( ary, 1 );

        

    }


}









