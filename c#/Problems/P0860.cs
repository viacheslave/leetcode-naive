using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/lemonade-change/
  ///    Submission: https://leetcode.com/submissions/detail/230677972/
  /// </summary>
  internal class P0860
  {
    public class Solution
    {
      public bool LemonadeChange(int[] bills)
      {
        var tens = 0;
        var fives = 0;

        foreach (var b in bills)
        {
          if (b == 5)
            fives++;

          if (b == 10)
          {
            if (fives > 0)
            {
              fives--;
              tens++;
            }
            else
            {
              return false;
            }
          }

          if (b == 20)
          {
            if (fives == 0)
              return false;

            if (tens > 0)
            {
              fives--;
              tens--;
            }
            else if (fives > 2)
            {
              fives -= 3;
            }
            else
            {
              return false;
            }
          }
        }

        return true;
      }
    }
  }
}
