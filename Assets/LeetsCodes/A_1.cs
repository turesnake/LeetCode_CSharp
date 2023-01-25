using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

/*
    0001: 两数之和;
*/
public class A_1 
{

    /*
        主流思路:
        使用 unordered_multimap 来管理本题的数据;
        c# 中则是  Dictionary<int,Stack<int>>
    */
    public static int[] TwoSum_4( int[] nums, int target ) 
    {
        Dictionary<int,Stack<int>> dic = new Dictionary<int, Stack<int>>();

        for( int i=0; i<nums.Length; i++ )
        {
            int k = nums[i];
            dic.TryAdd( k, new Stack<int>() );
            dic[k].Push( i );
        }

        foreach( var l in nums )
        {
            int r = target - l;

            // 这种思路的一个小陷阱: 
            if( l == r ) 
            {
                if( dic[l].Count == 2 ) 
                {
                    return new int[]{ dic[l].Pop(), dic[l].Pop() };
                }
                else 
                {
                    continue;
                }
            }

            if( dic.ContainsKey(r) )
            {
                int or = dic[r].Pop();
                int ol = dic[l].Pop();
                return new int[]{ ol, or };
            }
        }
        return null;
    }


    /*
        最 直观 和低效 的做法; n^2
        因为不能改变元素的顺序, (这样各元素的 idx 会变, 进而导致 无法上来就使用 排序,
        使得不能用 双指针 从两头向中间逼近;
    */
    public static int[] TwoSum_1( int[] nums, int target ) 
    {
        int len = nums.Length;
        for( int l=0; l<len-1; l++ ) 
        {
            for( int r=l+1; r<len; r++  )
            {
                if( nums[l] + nums[r] == target ){
                    return new int[]{ l,r };
                }
            }
        }
        return null;
    }


    /*
        把原始元素的 idx 存到一个 unordered_multimap 中, 
        然后排序, 然后双指针 从两侧往中间走; 
        ---
        注意, 这个方法想复杂了, 不推荐 !!!!!
    */
    public static int[] TwoSum_2( int[] nums, int target ) 
    {
        List<int> ns = new List<int>();
        ns.AddRange( nums );

        Dictionary<int,List<int>> dic = new Dictionary<int, List<int>>();
        for( int i=0; i<ns.Count; i++ )
        {
            int key = ns[i];
            dic.TryAdd( key, new List<int>() );
            dic[key].Add( i );
        }

        ns.Sort(); // 升序 排序自己;

        int len = ns.Count;
        int l = 0;
        int r = len-1;

        while( l < r ) 
        {
            int sum = ns[l] + ns[r];
            if( sum < target ) 
            {
                l++;
            }
            else if( sum > target ) 
            {
                r--;
            }
            else 
            {
                // --- 找到了 ---:
                var ll = dic[ns[l]];
                int ol = ll[ ll.Count-1 ];
                ll.RemoveAt( ll.Count-1 );

                var lr = dic[ns[r]];
                int or = lr[ lr.Count-1 ];
                // 此处就不用 remove 了反正也用不到了

                return new int[]{ ol, or };
            }
        }
        return null;
    }


    /*
        第二版的改版, 用 Stack<int> 替换 List<int>;
        ---
        注意, 这个方法想复杂了, 不推荐 !!!!!
    */
    public static int[] TwoSum_3( int[] nums, int target ) 
    {
        List<int> ns = new List<int>();
        ns.AddRange( nums );

        Dictionary<int,Stack<int>> dic = new Dictionary<int, Stack<int>>();
        for( int i=0; i<ns.Count; i++ )
        {
            int key = ns[i];
            dic.TryAdd( key, new Stack<int>() );
            dic[key].Push( i );
        }

        ns.Sort(); // 升序 排序自己;

        int len = ns.Count;
        int l = 0;
        int r = len-1;

        while( l < r ) 
        {
            int sum = ns[l] + ns[r];
            if( sum < target ) 
            {
                l++;
            }
            else if( sum > target ) 
            {
                r--;
            }
            else 
            {
                // --- 找到了 ---:
                int ol = dic[ns[l]].Pop();
                int or = dic[ns[r]].Pop();
                return new int[]{ ol, or };
            }
        }
        return null;
    }



    // 20230124
    // 因为本题保证只有 一对正确值, 所以边界检查可以省略很多
    public static int[] TwoSum_5( int[] nums, int target ) 
    {
        int len = nums.Length;
        Dictionary<int,List<int>> dic = new Dictionary<int, List<int>>(); // unordered_multimap

        for( int i=0; i<len; i++ ) 
        {
            int key = nums[i];
            if( dic.ContainsKey(key) == false )
            {
                dic.Add( key, new List<int>() );
            }
            dic[key].Add(i);
        }

        for( int i=0; i<len; i++ ) 
        {
            int a = nums[i];
            int b = target - a;

            if( dic.ContainsKey(b) == true ) 
            {
                if( a == b )
                {
                    if( dic[a].Count == 2 ){     // !!!! 陷阱, 可能只有一个元素, 比如 ( {3,2,4}, 6 ); 此处只有一个 3
                        return dic[a].ToArray(); 
                    }
                }
                else 
                {
                    return new int[]{ i, dic[b][0] }; // dic[b] 一定只有一个元素
                }
            }
        }
        return null; // 不可能达到
    }



}


