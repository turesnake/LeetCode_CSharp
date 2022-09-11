using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    0002: 两数相加
*/


public class A_0002
{

    static ListNode recu(ListNode l1, ListNode l2, int quot_) 
    {
        if( l1==null && l2==null && quot_==0 ) 
        {
            return null;
        }

        int v1 = l1==null ? 0 : l1.val;
        int v2 = l2==null ? 0 : l2.val;

        int mod  = (v1 + v2 + quot_)%10;
        int quot = (v1 + v2 + quot_)/10;

        return new ListNode( mod, recu( l1==null ? null : l1.next, l2==null ? null : l2.next, quot ) );
    }


    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2) 
    {


        return recu( l1, l2, 0 );
    }



}





