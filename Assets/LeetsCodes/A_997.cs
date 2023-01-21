using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    997. 找到小镇的法官

    
*/
public class A_997
{
    // 不管 平民可以信任法官, 平民也能信任平民

    // 如果能找到 每个平民信任法官的信息, 以及法官不信任任何平民的信息, 则能找到法官;

    class Ent 
    {
        public List<int> childs = new List<int>();
        public List<int> parents = new List<int>();
    }


    public int FindJudge(int n, int[][] trust) 
    {   
        List<Ent> ents = new List<Ent>();

        for( int i=0; i<=n; i++ ) // 多压入一位方便索引, [0]无用
        {
            ents.Add( new Ent() );
        }

        // 装填数据:
        foreach( var p in trust ) 
        {
            ents[p[1]].childs.Add( p[0] );
            ents[p[0]].parents.Add( p[1] );
        }

        // 若某个元素的 child 数量为 n-1, parent 为 0, 则它是法官:
        for( int i=1; i<=n; i++ )//跳过 [0] 元素
        {
            var e = ents[i];
            if( e.childs.Count == n-1 && e.parents.Count == 0 )
            {
                return i;
            }
        }
        return -1;
    }


}






