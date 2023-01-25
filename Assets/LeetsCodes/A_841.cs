using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;



/*
    841. 钥匙和房间

    

    bfs dfs 应该就能解决

*/
public class A_841
{
    bool[] flags;

    public bool CanVisitAllRooms_BFS( IList<IList<int>> rooms ) 
    {
        int n = rooms.Count;

        flags = new bool[n];
        Array.Fill( flags, false );
        int count = 0;


        LinkedList<int> deque = new LinkedList<int>();
        deque.AddLast( 0 );
        

        while( deque.Count > 0 ) 
        {
            int roomID = deque.First.Value;
            deque.RemoveFirst();

            if( flags[roomID] == false ) 
            {
                flags[roomID] = true;
                count++;

                foreach( var e in rooms[roomID] ) 
                {
                    deque.AddLast( e );
                }
            }
        }
        return count == n;
    }


    
     

    public static void Main() 
    {
        var instance = new A_841();


        IList<IList<int>> rooms = new List<IList<int>>()
        {
            new List<int>(){ 1 },
            new List<int>(){ 2 },
            new List<int>(){ 3 },
            new List<int>(){  }
        };

        bool ret = instance.CanVisitAllRooms_BFS( rooms );


        
        

    }

}






