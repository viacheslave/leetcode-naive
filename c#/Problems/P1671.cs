using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-number-of-removals-to-make-mountain-array/
  ///    Submission: https://leetcode.com/submissions/detail/425401036/
  /// </summary>
  internal class P1671
  {
    public class Solution
    {
      public int MinimumMountainRemovals(int[] nums)
      {
        var ans = int.MinValue;

        var pre = LengthOfLIS(nums);
        var suf = LengthOfLIS(nums.Reverse().ToArray());

        for (var top = 1; top < nums.Length - 1; top++)
        {
          if (nums[top - 1] <= nums[top] && nums[top] >= nums[top + 1])
          {
            // top found
            var left = pre[top];
            var right = suf[nums.Length - top - 1];

            ans = Math.Max(ans, left + right - 1);
          }
        }

        return nums.Length - ans;
      }

      public int[] LengthOfLIS(int[] nums)
      {
        var dp = Enumerable.Repeat(1, nums.Length).ToArray();

        for (var i = 1; i < nums.Length; i++)
          for (var j = 0; j < i; j++)
            if (nums[i] > nums[j] && dp[i] < dp[j] + 1)
              dp[i] = dp[j] + 1;

        return dp;
      }
    }
  }
}
