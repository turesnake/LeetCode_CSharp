using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;




/*
    剑指 Offer 40. 最小的k个数


    小顶堆, (最小元素在顶部) 不关心元素重复和顺序;


    !!!!!
    但是上面这个思路是不完善的.
    如果用 小顶堆, 则要将全部元素入堆;
    其实可以改用 大顶堆, 然后全程只维护 k 个元素....

    

*/


// 自己瞎捣鼓的 小顶堆,
// 如上所述, 思路是不完善的, 应该改用 大顶堆...
public class JZ_Offer_40
{
    int idx; // current 
    int[] heap;


    void Add( int val )
    {
        idx++;
        int n = idx;

        heap[n] = val; 

        int p = (n-1)/2;

        while( n>0 && heap[p] > heap[n] ) 
        {
            (heap[p], heap[n]) = (heap[n], heap[p]); // swap 
            n = p;
            p = (n-1)/2;
        }
    }


    int GetMin() 
    {
        (heap[0], heap[idx]) = (heap[idx], heap[0]);
        idx--;

        int n = 0;
        int l;
        int r;

        while( idx > 2*n )
        {
            l = 2*n+1;
            r = 2*n+2;

            int lv = (l<=idx) ? heap[l] : int.MaxValue;
            int rv = (r<=idx) ? heap[r] : int.MaxValue;
            int tgt = (lv <= rv) ? l : r; 

            if( heap[n] <= heap[tgt] ) 
            {
                break;
            }

            (heap[n], heap[tgt]) = (heap[tgt], heap[n]);
            n = tgt;
        }

        return heap[idx+1];
    }




    public int[] GetLeastNumbers( int[] arr, int k ) 
    {
        int len = arr.Length;
        if( len == 0 ) 
        {
            return new int[0];
        }
        
        heap = new int[len];

        heap[0] = arr[0];
        idx = 0;

        for( int i=1; i<len; i++ )// 掠过元素[0] 
        {
            Add( arr[i] );
        }
        //---:
        int[] ret = new int[k];
        for( int i=0; i<k; i++ ) 
        {
            ret[i] = GetMin();
        }
        return ret;
    }

    

    public static void Main() 
    {
        var instance = new JZ_Offer_40();

        //int[] arr = { 6,13,4,3,10,1,7,2,5,9,2,7,1,8,7,4,1,3,2,5 };
        int[] arr = {  };
        //int[] arr = { 5,4,3,2,1 };


        var ret = instance.GetLeastNumbers( arr, 0 );
        foreach( var e in ret ) 
        {
            Debug.Log( e );
        }


    }
    
    
}





