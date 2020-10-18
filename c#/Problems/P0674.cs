using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-continuous-increasing-subsequence/
  ///    Submission: https://leetcode.com/submissions/detail/232269691/
  /// </summary>
  internal class P0674
  {
    public class Solution
    {
      public int FindLengthOfLCIS(int[] nums)
      {
        if (nums.Length == 0)
          return 0;

        var start = 0;
        var end = start;
        var max = 1;

        for (var i = 1; i < nums.Length; i++)
        {
          if (nums[i] <= nums[i - 1])
          {
            start = i;
            end = start;
            continue;
          }

          end = i;
          var m = end - start + 1;
          if (m > max)
            max = m;
        }

        return max;

      }
    }
  }
}
