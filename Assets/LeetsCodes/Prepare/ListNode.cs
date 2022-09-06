using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


// 以防存在别的类型的 ListNode, 所以用 namespace 来作区分;
namespace A{

    // Definition for singly-linked list.
    public class ListNode 
    {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) 
        {
            this.val = val;
            this.next = next;
        }
        
        // ======================== 下面是私建内容 ======================== //

        // 尾递归 
        static ListNode recu( List<int> nums, int idx )
        {
            if( idx == nums.Count-1 )
            {
                return new ListNode( nums[idx], null );
            }
            return new ListNode( nums[idx], recu( nums, idx+1 ) );
        }


        public static ListNode Create( List<int> nums )
        {
            if( nums == null || nums.Count == 0 )
            {
                return null;
            }
            return recu( nums, 0 );
        }


        public static void Print( ListNode node, string strHead = "" )
        {
            if( node == null )
            {
                Debug.Log("Empty ListNode");
                return;
            }
            int nodeNum = 0;
            string str = strHead + "  ListNode = ";
            while( node != null )
            {
                str += node.val + ", ";
                node = node.next;
                nodeNum++;
            }
            Debug.Log( str + "\n node Num = " + nodeNum );
        }

    }

}
