using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/range-sum-of-sorted-subarray-sums/
  ///    Submission: https://leetcode.com/submissions/detail/374444439/
  /// </summary>
  internal class P1508
  {
    public class Solution
    {
      public int RangeSum(int[] nums, int n, int left, int right)
      {
        var mod = 1_000_000_007;

        var sums = new List<int>();

        for (var i = 0; i < n; i++)
        {
          var b = nums[i];
          sums.Add(b);

          for (var j = i + 1; j < n; j++)
          {
            b += nums[j];
            sums.Add(b);
          }
        }

        sums.Sort();

        var elements = sums.Skip(left - 1).Take(right - left + 1);

        var ans = 0;

        foreach (var el in elements)
        {
          ans += el;
          ans %= mod;
        }

        return ans;
      }
    }
  }
}
