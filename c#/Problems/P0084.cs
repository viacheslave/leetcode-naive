using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/largest-rectangle-in-histogram/
  ///    Submission: https://leetcode.com/submissions/detail/414260391/
  /// </summary>
  internal class P0084
  {
    public class Solution
    {
      public int LargestRectangleArea(int[] heights)
      {
        var ans = 0;

        if (heights.Length == 0)
          return 0;

        for (var i = 0; i < heights.Length; i++)
        {
          ans = Math.Max(ans, heights[i]);
          var min = heights[i];

          for (var j = i - 1; j >= 0; j--)
          {
            if (heights[j] == 0)
              break;

            min = Math.Min(min, heights[j]);
            ans = Math.Max(ans, ((i - j) + 1) * min);
          }
        }

        return ans;
      }
    }
  }
}
