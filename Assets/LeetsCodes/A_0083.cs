using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using A;



/*
    0083: 删除排序链表中的重复元素
*/
public class A_0083
{

    /*
        尾递归
    */
    public static void recu( ListNode head ) 
    {
        if( head==null || head.next==null )
        {
            return;
        }
        // 现在保证 head, head.next, head.next.next 都是可访问的;
        if( head.val == head.next.val )
        {
            head.next = head.next.next;
        }
        else 
        {
            head = head.next;
        }
        recu( head );
    }


    public static ListNode DeleteDuplicates( ListNode head ) 
    {
        recu( head );
        return head;
    }







    public static void Main() 
    {

        //var node1 = ListNode.Create( new List<int>(){ 1,2,4 } );
        var node1 = ListNode.Create( new List<int>(){ 1,1,1,2,2,2,2,2,2,3,3,3,4,5,5,5,6,8,8,8,9 } );
        ListNode.Print( node1, "node1 :" );




        var retNode = DeleteDuplicates( node1 );
        ListNode.Print( retNode, "retNode :" );



    }
}

