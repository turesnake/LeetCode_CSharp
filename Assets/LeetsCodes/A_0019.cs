using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    0019: 删除链表的倒数第 N 个结点
*/


public class A_0019
{

   

    //
    static int recu(ListNode p, int n) 
    {
        if( p.next == null )
        {
            return 1; // 上一层, 即 p.next 是 尾端节点, 序号为 1
        }

        int retN = recu(p.next, n);

        if( n == retN ) 
        {
            p.next = p.next.next;
        }
        return retN + 1;
    }   


    public static ListNode RemoveNthFromEnd(ListNode head, int n) 
    {
        ListNode before = new ListNode( 0, head ); // 前导节点

        recu( before, n );

        return before.next;
    }



}





