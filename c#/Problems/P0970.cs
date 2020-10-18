using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/powerful-integers/
  ///    Submission: https://leetcode.com/submissions/detail/231310358/
  /// </summary>
  internal class P0970
  {
    public class Solution
    {
      public IList<int> PowerfulIntegers(int x, int y, int bound)
      {
        var hs = new HashSet<int>();

        var ilog = x == 1 ? 0 : (int)Math.Log(bound - 1, x) + 1;
        var jlog = y == 1 ? 0 : (int)Math.Log(bound - 1, y) + 1;

        for (var i = 0; i <= ilog; i++)
        {
          for (var j = 0; j <= jlog; j++)
          {
            var value = (int)Math.Pow(x, i) + (int)Math.Pow(y, j);
            if (value <= bound)
              hs.Add(value);
          }
        }

        return hs.ToArray();
      }
    }
  }
}
