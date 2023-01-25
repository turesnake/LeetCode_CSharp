using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;



/*
    15. 三数之和

    

    

*/
public class A_15
{

    
    // 固定好一个元素 a, 然后在剩余的数据里 查找 b 和 c;

    // 依然是 哈希表法

    public IList<IList<int>> ThreeSum( int[] nums ) 
    {
        IList<IList<int>> ret = new List<IList<int>>();

        Array.Sort( nums ); // 升序

        SortedList<int,int> sdic = new SortedList<int, int>(); // key: 元素值, val: 元素个数,
        foreach( var e in nums )
        {
            if( sdic.ContainsKey(e) == false ) 
            {
                sdic.Add( e, 0 );
            }
            sdic[e]++;
        }

        for( int i=0; i<sdic.Count; i++ )
        {
            int a = sdic.Keys[i];
            sdic[a]--; // 现在这个 val 可能为 0

            if( a > 0 )
            {
                continue;
            }

            // ---::
            int j = sdic[a]>0 ? i : i+1;
            for( ; j<sdic.Count; j++ ) 
            {
                int b = sdic.Keys[j];
                int tgt = 0 - a - b;

                if( tgt < b ) 
                {
                    continue;
                }

                bool isAdd = false;

                if( b == tgt )
                {
                    if( sdic[b] > 1 ) 
                    {
                        isAdd = true;
                    }
                }
                else 
                {
                    if( sdic.ContainsKey(tgt) && sdic[tgt] > 0 )
                    {
                        isAdd = true;
                    }
                }

                if( isAdd )
                {
                    ret.Add( new List<int>(){ a, b, tgt } );
                }

            }
        }

        return ret;
    }


    // 尝试 排序 + 双指针 法:
    public IList<IList<int>> ThreeSum_2( int[] nums ) 
    {

        IList<IList<int>> ret = new List<IList<int>>();

        Array.Sort( nums ); // 升序









        return null;
    }
    
     

    public static void Main() 
    {
        var instance = new A_15();

        int[] nums = { -1,0,1,2,-1,-4 };
        //int[] nums = { -2,0,0,0,1,1 };


        var rets = instance.ThreeSum( nums );
        Debug.Log("------");
        foreach( var ret in rets ) 
        {
            Debug.Log( ret[0] + ", " + ret[1] + ", " + ret[2] );
        }

        
    
    }




}






