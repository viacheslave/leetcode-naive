using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/largest-number-at-least-twice-of-others/
  ///    Submission: https://leetcode.com/submissions/detail/232265056/
  /// </summary>
  internal class P0747
  {
    public class Solution
    {
      public int DominantIndex(int[] nums)
      {
        var max = nums.Max();
        var maxIndex = -1;

        for (var i = 0; i < nums.Length; i++)
        {
          if (nums[i] == max)
          {
            maxIndex = i;
            break;
          }
        }

        if (nums.All(_ => _ * 2 <= max || _ == max))
          return maxIndex;
        return -1;
      }
    }
  }
}
