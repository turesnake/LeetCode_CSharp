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

public class A_1996
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



    public static void Main()
    {

        //SortedDictionary<int,int> dic = new SortedDictionary<int, int>();
        // Dictionary<int,int> dic = new Dictionary<int, int>();

        // dic.Add( 5,9 );
        // dic.Add( 10,7 );
        // dic.Add( 9,5 );
        // dic.Add( 6,10 );
        // dic.Add( 11,6 );

        // string s = "";
        // foreach( var e in dic )
        // {
        //     s += e.Key + ", " + e.Value + "\n";
        // }

        // Debug.Log(s);

        // --------------------------------------------------

        // int[][] nums= new int[][]{
        //     new int[]{ 1,1 },
        //     new int[]{ 5,3 },
        //     new int[]{ 2,1 },
        //     new int[]{ 3,1 },
        //     new int[]{ 7,1 },
        //     new int[]{ 5,2 },
        //     new int[]{ 3,2 },
        // };

        // ILookup<int, int> map = nums.ToLookup(
        //     p => p[0],
        //     p => p[1]
        // );

        // string s ="";
        // foreach( var e in map )
        // {
        //     s += e.Key + ", \n";

        //     foreach( var a in e )
        //     {
        //         s += "    " + a + "\n";
        //     }
        // }
        // Debug.Log(s);


        //Test001.Main();

        // -----------------------------------------

        // int[][] nums= new int[][]{
        //     new int[]{ 1,1 },
        //     new int[]{ 5,3 },
        //     new int[]{ 2,1 },
        //     new int[]{ 3,1 },
        //     new int[]{ 7,1 },
        //     new int[]{ 5,2 },
        //     new int[]{ 3,2 },
        // };

        // Array.Sort(
        //     nums,
        //     (o1,o2)=>o1[0]==o2[0] ?
        //         o1[1]-o2[1] :
        //         o2[0]-o1[0]
        // );

        // string s ="";
        // foreach( var e in nums )
        // {
        //     s += e[0] + ", " + e[1] + "\n";
        // }
        // Debug.Log(s);
        
        // -----------------------------------------------

        // int[] nums = new int[]{ 5,1,7,6,2,4 };
        // Array.Sort( nums,
        //     (a,b)=>b-a
        // );

        // foreach( var e in nums )
        // {
        //     Debug.Log( e );
        // }
        
        // -----------------------------------------------

        int[,] nums = {
                    {1,1},
                    {2,2},
                    {3,3}
                };

        Debug.Log( nums.GetLowerBound(0) + ",  " + nums.GetUpperBound(0) );
        Debug.Log( nums.GetLowerBound(1) + ",  " + nums.GetUpperBound(1) );


        

    }

    class D 
    {
        public int val = 0;
        public D( int v ) 
        {
            val = v;
        }
    }


    
    public static IEnumerable<T> AsReverseEnumerator<T>(this IReadOnlyList<T> list)
    {
        for (int i = list.Count; --i >= 0;) yield return list[i];
    }

    

}


static class Extensions 
{
    public static IEnumerable<T> ReverseEx<T>(this IEnumerable<T> coll) 
    {
        var quick = coll as IList<T>;
        if (quick == null) {
            foreach (T item in coll.Reverse()) yield return item;
        }
        else {
            for (int ix = quick.Count - 1; ix >= 0; --ix) {
                yield return quick[ix];
            }
        }
    }
}






