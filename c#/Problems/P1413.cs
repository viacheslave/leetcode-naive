using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-value-to-get-positive-step-by-step-sum/
  ///    Submission: https://leetcode.com/submissions/detail/327765976/
  /// </summary>
  internal class P1413
  {
    public class Solution
    {
      public int MinStartValue(int[] nums)
      {
        var diff = new int[nums.Length];
        diff[0] = nums[0];

        for (int i = 1; i < nums.Length; i++)
          diff[i] = diff[i - 1] + nums[i];

        var min = diff.Min();
        return Math.Max(1, 1 - min);
      }
    }
  }
}
