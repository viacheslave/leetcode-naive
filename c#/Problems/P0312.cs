using System;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/burst-balloons/
  ///    Submission: https://leetcode.com/submissions/detail/430188067/
  /// </summary>
  internal class P0312
  {
    public class Solution
    {
      public int MaxCoins(int[] nums)
      {
        var arr = nums.ToList();
        arr.Insert(0, 1);
        arr.Add(1);

        nums = arr.ToArray();

        var dp = new int[nums.Length + 1, nums.Length + 1];

        for (var wd = 1; wd < nums.Length; wd++)
        {
          for (var start = 0; start < nums.Length - wd - 1; start++)
          {
            var left = start;
            var right = left + wd + 1;

            for (var index = left + 1; index < right; index++)
            {
              // last ballon to be burst divides the problem into left and right sub-problems
              // after left and right problems are resolved, last baloon value is nums[index] * nums[left] * nums[right]

              dp[left, right] = Math.Max(dp[left, right],
                nums[index] * nums[left] * nums[right] +
                dp[left, index] +
                dp[index, right]);
            }
          }
        }

        return dp[0, nums.Length - 1];
      }
    }
  }
}
