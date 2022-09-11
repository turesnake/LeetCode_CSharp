using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    0203: 移除链表元素


*/
public class A_0203
{

    /*
        递归版
    */
    public static ListNode RemoveElements(ListNode head, int val) 
    {
        if( head == null )
        {
            return null;
        }

        if( head.val == val )
        {
            return RemoveElements( head.next, val );
        }
        else 
        {
            head.next = RemoveElements( head.next, val );
            return head;
        }
    }


    /*
        遍历版:
            每次删除的都是 next 节点, 所以要事先在 链表之前再加一个额外的 头节点, 来统一操作;
    */
    public static ListNode RemoveElements_2(ListNode head, int val) 
    {
        ListNode before = new ListNode( 0, head );
        ListNode p = before;

        while( p.next != null )
        {
            if( p.next.val == val )
            {   
                p.next = p.next.next;
            }
            else
            {
                p = p.next;
            }
        }

        return before.next;
    }


    
    
}

