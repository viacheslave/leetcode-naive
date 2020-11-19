using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-moves-to-equal-array-elements-ii/
  ///    Submission: https://leetcode.com/submissions/detail/421968910/
  /// </summary>
  internal class P0462
  {
    public class Solution
    {
      public int MinMoves2(int[] nums)
      {
        if (nums.Length == 0)
          return 0;

        var min = (long)nums.Min();
        var max = (long)nums.Max();

        if (min == max)
          return 0;

        var left = min;
        var right = max;

        while (true)
        {
          if (right - left == 2)
          {
            var mid = (left + right) / 2;

            var smid = GetSteps(mid, nums);
            var sleft = GetSteps(left, nums);
            var sright = GetSteps(right, nums);

            var ans = Math.Min(smid, Math.Min(sleft, sright));
            return (int)ans;
          }

          if (right - left == 1)
          {
            var sleft = GetSteps(left, nums);
            var sright = GetSteps(right, nums);

            var ans = Math.Min(sleft, sright);
            return (int)ans;
          }

          var m = (left + right) / 2;

          var ssmid = GetSteps(m, nums);
          var ssleft = GetSteps(m - 1, nums);
          var ssright = GetSteps(m + 1, nums);

          if (ssmid < ssleft && ssmid < ssright)
            return (int)ssmid;

          if (ssleft < ssmid && ssmid < ssright)
            right = m;
          else
            left = m;
        }
      }

      private long GetSteps(long mid, int[] arr)
      {
        long ans = 0;

        for (var i = 0; i < arr.Length; i++)
        {
          ans += Math.Abs(mid - arr[i]);
        }

        return ans;
      }
    }
  }
}
