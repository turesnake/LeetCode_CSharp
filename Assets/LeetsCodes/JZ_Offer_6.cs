using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    剑指 Offer 06: 从尾到头打印链表
*/


// 递归法
public class JZ_Offer_6
{
    
    static void recu( ListNode node, List<int> lst  ) 
    {
        if( node == null )
        {
            return;
        }
        recu(node.next, lst);

        lst.Add( node.val );
        return;
    }

    public static int[] ReversePrint(ListNode head) 
    {
        List<int> rets = new List<int>();
        recu( head, rets );
        return rets.ToArray();
    }
}





