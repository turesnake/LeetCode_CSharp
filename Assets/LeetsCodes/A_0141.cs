using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using A;


/*
    0141: 环形链表
*/
public class A_0141
{

    /*
        set 法, 把每个指针存储下来, 发现那个重复了, 就判断存在环;
        对内存不够友好
    */
    public static bool HasCycle_1(ListNode head) 
    {

        HashSet<ListNode> set = new HashSet<ListNode>();

        while( head != null )
        {
            if( set.Contains(head) == true )
            {
                return true;
            }
            set.Add(head);
            head = head.next;
        }
        return false;
    }


    /*
        快慢指针, 内存消耗为 1
    */
    public static bool HasCycle_2(ListNode head) 
    {

        if( head==null || head.next==null )
        {
            return false;
        }
        ListNode l = head;
        ListNode r = head.next;

        while( l!=r )
        {
            // r跑得快, 所以只需检测 r
            if( r.next==null || r.next.next==null )
            {
                return false;
            }
            l = l.next;
            r = r.next.next;
        }
        return true;
    }



    public static void Main() 
    {
        // 因为有 环表, 没法复现了;
        // 直接在 leetcode 中测试;
    }
}

