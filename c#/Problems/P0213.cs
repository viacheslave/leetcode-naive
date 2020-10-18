using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/house-robber-ii/
  ///    Submission: https://leetcode.com/submissions/detail/242001218/
  /// </summary>
  internal class P0213
  {
    public class Solution
    {
      public int Rob(int[] nums)
      {
        if (nums.Length == 1)
          return nums[0];

        return Math.Max(
            RobInternal(nums.Take(nums.Length - 1).ToList()),
            RobInternal(nums.Skip(1).Take(nums.Length - 1).ToList())
        );
      }

      public int RobInternal(List<int> nums)
      {
        var max = 0;

        var dp = new Dictionary<int, int>();
        dp[-1] = 0;
        dp[-2] = 0;
        dp[-3] = 0;

        for (int i = 0; i < nums.Count; i++)
        {
          dp[i] = nums[i] + Math.Max(dp[i - 2], dp[i - 3]);
          max = Math.Max(max, dp[i]);
        }

        return max;
      }
    }
  }
}
