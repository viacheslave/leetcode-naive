using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-length-of-subarray-with-positive-product/
  ///    Submission: https://leetcode.com/submissions/detail/390061767/
  /// </summary>
  internal class P1567
  {
    public class Solution
    {
      public int GetMaxLen(int[] nums)
      {
        var arrs = new List<(int, int)>();

        var l = nums.ToList();

        var current = 0;
        while (current < nums.Length)
        {
          var nonZero = l.FindIndex(current, x => x != 0);
          var zero = l.FindIndex(current, x => x == 0);

          if (nonZero == -1)
          {
            break;
          }

          if (zero == -1)
          {
            arrs.Add((nonZero, nums.Length - 1));
            break;
          }

          if (zero < nonZero)
          {
            current = zero + 1;
          }
          else
          {
            arrs.Add((nonZero, zero - 1));
            current = zero + 1;
          }
        }

        var ans = 0;

        foreach (var arr in arrs)
        {
          var a = new int[arr.Item2 - arr.Item1 + 1];
          Array.Copy(nums, arr.Item1, a, 0, a.Length);

          var negativesCount = a.Count(e => e < 0);
          if (negativesCount % 2 == 0)
          {
            ans = Math.Max(ans, a.Length);
            continue;
          }

          var list = a.ToList();
          var firstNegative = list.FindIndex(e => e < 0);
          var lastNegative = list.FindLastIndex(e => e < 0);

          var minDiff = Math.Min(firstNegative, a.Length - 1 - lastNegative);
          ans = Math.Max(ans, a.Length - minDiff - 1);
        }

        return ans;
      }
    }
  }
}
