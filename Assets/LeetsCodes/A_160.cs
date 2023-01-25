using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    0160: 相交链表


    你能否设计一个时间复杂度 O(m + n) 、仅用 O(1) 内存的解决方案？

    最笨法:
        将 a表所有节点 录入 set, 然后拿着 b表 的每隔节点去查找是否重合;

    内存 O(1) 法大概率又是 双指针法...
*/
public class A_160
{

    /*
        两个指针, 指针 l 跑完 a 之后立刻跑 b, 指针 r 跑完 b 之后立刻跑 a;
        两个链表总有一个稍微长点, 等长点的那个跑完了, 先跑短的那个已经在跑长的了;
        此时, 两个指针的 后续遍历元素个数 是相同的
    */
    public static ListNode GetIntersectionNode( ListNode headA, ListNode headB )
    {

        ListNode l = headA;
        ListNode r = headB;
        bool isLChange = false;
        bool isRChange = false;

        while( true )
        {
            bool isAnyChange = false;
            // 本链表读完后, 读另一个链表
            if( !isLChange && l==null )
            {
                l = headB;
                isLChange = true;
                isAnyChange = true;
            }
            if( !isRChange && r==null )
            {
                r = headA;
                isRChange = true;
                isAnyChange = true;
            }

            if( isAnyChange  )
            {
                if( isLChange && isRChange ) 
                {
                    break;
                }
                else 
                {
                    continue;
                }
            }

            l = l.next;
            r = r.next;
        }
        // 现在, 两个指针 后续要遍历的 节点数是相同的了;
        // 什么时候两节点相同了, 就能返回了

        while( l!=null )
        {
            if( l == r )
            {
                return l;
            }

            l = l.next;
            r = r.next;
        }

        return null; // 说明两链表 不相交
    }


    
    public static void Main() 
    {
        // 因为有 相交表, 没法复现了;
        // 直接在 leetcode 中测试;
    }
}

