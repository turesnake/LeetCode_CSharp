using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


using TypeA;


/*
    1996: 游戏中弱角色的数量

    只要任何一个原始 j 强于 i, 那么就可判定 i 为弱智; 然后计数器加一;
    ---
    (1) 方法1, 最直观的思路:
    思路:
    先按照 攻击值排序, 攻击值相同的丢到一个桶里;
    每个桶记录自己的最大攻击值;
    上述用一个 sorted multi map 来实现;

    排序完成后, 遍历这个队列, 第一个(攻击值最大)元素不作数
    后面的每个桶, 遍历自身的 每个元素, 去和当前 max 值做比较, 判断自己是不是弱者

    ------
    (2) 精简解法:
    上面这个思路之所以搞得这么复杂, 就是因为 攻击值最大的那些元素, 里面就算是 防御值较小的, 也不能成为 弱者;

    有个方法可以变相达到此目的:
    直接对 int[][] 排序, 先按攻击值排序, 第二排序规则是 防御值从小到大; (而不是从大到小...)
    ---
    非常精妙...
    
*/

public class A_1996__
{

    class Data 
    {
        public int maxVal;
        public List<int> elems = new List<int>();
        public Data( int val ) 
        {
            this.maxVal = val;
            elems.Add( val );
        }
    }

    class DescendingComparer<T> : IComparer<T> where T : IComparable<T> 
    {
        public int Compare(T x, T y) 
        {
            return y.CompareTo(x); // 倒着比较
        }
    }


    public static int NumberOfWeakCharacters(int[][] properties) 
    {

        SortedDictionary<int, Data> dic = new SortedDictionary<int, Data>(new DescendingComparer<int>());
        foreach( var e in properties)
        {
            if( dic.TryGetValue( e[0], out Data data ) )
            {
                data.maxVal = Math.Max(data.maxVal, e[1]);
                data.elems.Add( e[1] );
            }
            else 
            {
                dic.Add( e[0], new Data( e[1]) );
            }
        }

        int sum = 0;
        int maxVal = 0;
        Data fstData = null;
        foreach( var e in dic )
        {
            if( fstData == null )
            {
                fstData = e.Value;
                maxVal = fstData.maxVal;
                continue;
            }
            // 处理后续元素:
            foreach( var k in e.Value.elems ) 
            {
                if( k < maxVal )
                {
                    sum++;
                }
            }
            maxVal = Math.Max( maxVal, e.Value.maxVal );
        }

        return sum;
    }



    

    



}









