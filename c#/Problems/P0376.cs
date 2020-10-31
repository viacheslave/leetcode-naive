using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/wiggle-subsequence/
  ///    Submission: https://leetcode.com/submissions/detail/415217925/
  /// </summary>
  internal class P0376
  {
    public class Solution
    {
      public int WiggleMaxLength(int[] nums)
      {
        if (nums.Length == 0)
          return 0;

        var dp = new int[nums.Length, 2];

        // 0 up
        // 1 down

        dp[0, 0] = 1;
        dp[0, 1] = 1;

        for (var i = 1; i < nums.Length; i++)
        {
          var max0 = 1;
          var max1 = 1;

          for (var j = 0; j < i; j++)
          {
            if (nums[i] > nums[j])
              max1 = Math.Max(dp[j, 0] + 1, max1);

            if (nums[i] < nums[j])
              max0 = Math.Max(dp[j, 1] + 1, max0);
          }

          dp[i, 0] = max0;
          dp[i, 1] = max1;
        }

        var ans = 0;
        for (var k = 0; k < 2; k++)
          for (var i = 0; i < nums.Length; i++)
            ans = Math.Max(ans, dp[i, k]);

        return ans;
      }
    }
  }
}
