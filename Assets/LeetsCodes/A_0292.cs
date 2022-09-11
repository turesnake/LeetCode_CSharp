using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using TypeA;


/*
    0292: Nim 游戏

    有点类似 动态规划, 前三格为 true, 第四格为 false, 往后的每一格,都检测自己的前三格,
    只要能找到一个 false, 自己就能判断为 true, 若前三格都为 true, 自己为 false;

    但是这样一来整个数列就有规律了, 所以可以用数学归纳法 作弊
    
*/

public class A_0292
{

    public static bool CanWinNim(int n) 
    {
        return (n%4!=0);
    }

}





