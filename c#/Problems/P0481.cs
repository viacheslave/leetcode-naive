using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/magical-string/
  ///    Submission: https://leetcode.com/submissions/detail/244883400/
  /// </summary>
  internal class P0481
  {
    public class Solution
    {
      public int MagicalString(int n)
      {
        var list = new List<int>() { 1, 2, 2 };

        var current = 1;

        while (true)
        {
          if (list.Count >= n)
            return list.Take(n).Count(_ => _ == 1);

          current++;

          var number = list[list.Count - 1] == 1 ? 2 : 1;
          var count = list[current];

          list.AddRange(Enumerable.Repeat(number, count));
        }
      }
    }
  }
}
