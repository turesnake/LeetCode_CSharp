using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;




/*
    

    练习 c# Array 和 List 中的 Sort 的使用;


*/
public class SortTest_1
{

    public class WComparer : IComparer
    {
        public int Compare(System.Object x, System.Object y)
        {
            return ( ((A)x).w - ((A)y).w );
        }
    }


    public class A 
    {
        public int age;
        public int w; 
        public A( int age_, int w_ ) 
        {
            age = age_;
            w = w_;
        }
    }

    
     

    public static void Main() 
    {
        var instance = new SortTest_1();

        


        

        

        SortedList<int,int> sdic = new SortedList<int, int>();
        sdic.Add( 3, 3 );
        sdic.Add( 1, 1 );
        sdic.Add( 2, 2 );
        
        for( int i=0; i<sdic.Count; i++ )
        {
            Debug.Log( "key = " + sdic.Keys[i] + ", val = " + sdic.Values[i] );
        }





        //Predicate

    }

}






