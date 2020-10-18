using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/moving-stones-until-consecutive/
  ///    Submission: https://leetcode.com/submissions/detail/246224485/
  /// </summary>
  internal class P1033
  {
    public class Solution
    {
      public int[] NumMovesStones(int a, int b, int c)
      {
        var pos = new int[] { a, b, c };
        Array.Sort(pos);

        a = pos[0];
        b = pos[1];
        c = pos[2];

        if (b - a == 1 && c - b == 1)
          return new int[] { 0, 0 };

        if (b - a == 1 || c - b == 1)
        {
          if (c - a == 3)
            return new int[] { 1, 1 };

          if (b - a == 1)
            return new int[] { 1, c - b - 1 };
          if (c - b == 1)
            return new int[] { 1, b - a - 1 };
        }

        if (b - a == 2 || c - b == 2)
          return new int[] { 1, b - a - 1 + c - b - 1 };

        return new int[] { 2, b - a - 1 + c - b - 1 };
      }
    }
  }
}
