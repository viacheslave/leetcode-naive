using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
  ///    Submission: https://leetcode.com/submissions/detail/225962779/
  /// </summary>
  internal class P0034
  {
    public class Solution
    {
      public int[] SearchRange(int[] nums, int target)
      {
        int min = -1;
        int max = -1;

        for (var i = 0; i < nums.Length; i++)
        {
          if (nums[i] == target && min == -1)
          {
            min = i;
            max = i;
            continue;
          }

          if (nums[i] == target)
          {
            max = i;
          }
        }

        return new int[] { min, max };
      }
    }
  }
}
