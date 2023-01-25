using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    207. 课程表

    拓扑排序, 
    入度 + bfs 
    

*/
public class A_207
{

    class Node 
    {
        public int inDegree = 0; // 入度为 0 时意味着可以被学习了
        //public int outDegree;
        public List<int> nexts = new List<int>();
    }

    Node[] nodes;

    public bool CanFinish( int numCourses, int[][] prerequisites ) 
    {

        nodes = new Node[numCourses];
        for( int i=0; i<numCourses; i++ ) 
        {
            nodes[i] = new Node();
        }

        foreach( var e in prerequisites ) 
        {
            nodes[e[0]].inDegree++;
            nodes[e[1]].nexts.Add(e[0]);
        }


        // for( int i=0; i<numCourses; i++ ) 
        // {
        //     string s = i + ", inDegree = " + nodes[i].inDegree + "; nexts:";
        //     foreach( int id in nodes[i].nexts ) 
        //     {
        //         s += id + ", ";
        //     }
        //     Debug.Log(s);
        // }

        int learnedCount = 0;

        LinkedList<int> deque = new LinkedList<int>();

        for( int i=0; i<numCourses; i++ ) 
        {
            if( nodes[i].inDegree == 0 ) 
            {
                deque.AddLast(i);
            }
        }

        while( deque.Count > 0 ) 
        {
            int id = deque.First.Value;
            deque.RemoveFirst();
            Node node = nodes[id];
            //---:
            learnedCount++;
            foreach( var j in node.nexts ) 
            {
                nodes[j].inDegree--;
                if( nodes[j].inDegree == 0 ) 
                {
                    deque.AddLast(j);
                }
            }
        }

        //Debug.Log( "learnedCount = " + learnedCount );
        return learnedCount == numCourses;
    }


    
     

    public static void Main() 
    {
        var instance = new A_207();


        int[][] prerequisites = {
            new int[]{ 0,1 },
            new int[]{ 3,1 },
            new int[]{ 1,2 },
            new int[]{ 2,1 }
        };

        bool ret = instance.CanFinish( 4, prerequisites );
        Debug.Log( "ret = " + ret );

    

    }

}






