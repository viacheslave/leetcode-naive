using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/bulb-switcher/
  ///    Submission: https://leetcode.com/submissions/detail/230228197/
  /// </summary>
  internal class P0319
  {
    public class Solution
    {
      public int BulbSwitch(int n)
      {
        var maxSqrt = (int)Math.Sqrt(n);

        var i = 1;
        while (i < maxSqrt)
        {
          if (i * i < n)
            i++;
        }

        return maxSqrt;
      }
    }
  }
}
