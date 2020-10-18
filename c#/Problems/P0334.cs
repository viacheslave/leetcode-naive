using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/increasing-triplet-subsequence/
  ///    Submission: https://leetcode.com/submissions/detail/246453893/
  /// </summary>
  internal class P0334
  {
    public class Solution
    {
      public bool IncreasingTriplet(int[] nums)
      {
        var mins = new int[nums.Length];
        var maxs = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
          if (i == 0)
          {
            mins[i] = nums[i];
            maxs[nums.Length - 1] = nums[nums.Length - 1];
            continue;
          }

          mins[i] = Math.Min(mins[i - 1], nums[i]);
          maxs[nums.Length - 1 - i] = Math.Max(maxs[nums.Length - 1 - i + 1], nums[nums.Length - 1 - i]);
        }

        for (int i = 1; i < nums.Length - 1; i++)
        {
          if (mins[i - 1] < nums[i] && nums[i] < maxs[i + 1])
            return true;
        }

        return false;
      }
    }
  }
}
