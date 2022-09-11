using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    0206: 反转链表
*/

// 递归法
public class A_0206
{
    static ListNode recu(ListNode l, ListNode r ) 
    {
        if( r == null )
        {
            return l;
        }
        var n = r.next;
        r.next = l;
        return recu( r, n );
    }

    public static ListNode ReverseList(ListNode head) 
    {
        if( head == null )
        {
            return null;
        }
        var r = head.next;
        head.next = null;
        return recu( head, r );
    }
}


// 遍历法
public class A_0206_B
{

    public static ListNode ReverseList(ListNode head) 
    {
        if( head == null )
        {
            return null;
        }
        var l = head;
        var r = head.next;
        l.next = null;
        while( r!=null )
        {
            var n = r.next;
            // ---
            r.next = l;
            l = r;
            r = n;
        }
        return l;
    }
}


