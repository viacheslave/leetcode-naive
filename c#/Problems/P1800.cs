using System;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-ascending-subarray-sum/
  ///    Submission: https://leetcode.com/submissions/detail/491301308/
  /// </summary>
  internal class P1800
  {
    public class Solution
    {
      public int MaxAscendingSum(int[] nums)
      {
        var ans = int.MinValue;

        for (var i = 0; i < nums.Length; i++)
        {
          var sum = nums[i];

          for (var j = i + 1; j < nums.Length; j++)
          {
            if (nums[j] > nums[j - 1])
              sum += nums[j];
            else break;
          }

          ans = Math.Max(ans, sum);
        }

        return ans;
      }
    }
  }
}
