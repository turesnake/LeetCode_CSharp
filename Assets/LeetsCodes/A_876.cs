using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    0876: 链表的中间结点


    快慢指针法; 画图演算
*/
public class A_876
{


    
    public static ListNode MiddleNode(ListNode head) 
    {

        ListNode l = head;
        ListNode r = head;

        while( r!=null && r.next!=null )
        {
            l = l.next;

            r = r.next;
            if( r == null || r.next == null )
            {
                break;
            }
            r = r.next;
        }

        return l;
    }


    
    
}

