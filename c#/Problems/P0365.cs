using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/water-and-jug-problem/
  ///    Submission: https://leetcode.com/submissions/detail/244599967/
  /// </summary>
  internal class P0365
  {
    public class Solution
    {
      public bool CanMeasureWater(int x, int y, int z)
      {
        if (z == 0)
          return true;

        if (z > (x + y))
          return false;

        if (z == (x + y) || z == x || z == y)
          return true;

        if (x == y && z != x)
          return false;

        if (x == 0 || y == 0)
          return false;

        var els = new HashSet<int>();

        var min = Math.Min(x, y);
        var max = Math.Max(x, y);

        els.Add(max);

        var el = min;
        var current = 0;

        while (!els.Contains(el))
        {
          els.Add(el);

          while (current <= max)
            current += min;

          el = current - max;

          if (el == z || el + min == z || el + max == z)
            return true;

          current = el;
        }

        return false;
      }
    }
  }
}
