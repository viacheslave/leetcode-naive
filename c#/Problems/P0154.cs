using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii/
  ///    Submission: https://leetcode.com/submissions/detail/230000454/
  /// </summary>
  internal class P0154
  {
    public class Solution
    {
      public int FindMin(int[] nums)
      {
        if (nums.Length == 1)
          return nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
          if (nums[i] < nums[i - 1])
            return nums[i];
        }

        return nums[0];
      }
    }
  }
}
