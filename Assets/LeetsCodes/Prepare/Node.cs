using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


// 以防存在别的类型的 Node, 所以用 namespace 来作区分;
namespace TypeB 
{


public class Node 
{
    public int val;
    public IList<Node> neighbors;

    public Node() 
    {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) 
    {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) 
    {
        val = _val;
        neighbors = _neighbors;
    }
}

    

}
