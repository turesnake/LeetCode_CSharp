using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;



/*
    0021: 合并两个有序链表
*/
public class A_21
{
    /*
        使用 尾递归 来实现; 
    */
    public static ListNode MergeTwoLists(ListNode list1, ListNode list2) 
    {
        if( list1==null && list2==null )
        {
            return null;
        }
        if( list1 == null )
        {
            return list2;
        }   
        if( list2 == null )
        {
            return list1;
        } 

        int v = 0;
        if( list1.val <= list2.val  )
        {
            v = list1.val;
            list1 = list1.next;
        }
        else 
        {
            v = list2.val;
            list2 = list2.next;
        }
        return new ListNode( v, MergeTwoLists( list1, list2 ) );
    }




    public static void Main() 
    {

        //var node1 = ListNode.Create( new List<int>(){ 1,2,4 } );
        var node1 = ListNode.Create( new List<int>(){ 1,3,4 } );
        ListNode.Print( node1, "node1 :" );

        //var node2 = ListNode.Create( new List<int>(){ 1,3,4 } );
        var node2 = ListNode.Create( new List<int>(){ 0 } );
        ListNode.Print( node2, "node2 :" );


        var retNode = MergeTwoLists( node1, node2 );
        ListNode.Print( retNode, "retNode :" );



    }
}

