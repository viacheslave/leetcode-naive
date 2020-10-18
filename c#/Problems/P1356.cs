using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/sort-integers-by-the-number-of-1-bits/
  ///    Submission: https://leetcode.com/submissions/detail/308046668/
  /// </summary>
  internal class P1356
  {
    public class Solution
    {
      public int[] SortByBits(int[] arr)
      {
        return arr.OrderBy(Get)
            .ThenBy(a => a)
            .ToArray();
      }

      private int Get(int arg)
      {
        var ans = 0;

        while (arg > 0)
        {
          if (arg % 2 == 1)
            ans++;

          arg >>= 1;
        }

        return ans;
      }
    }
  }
}
