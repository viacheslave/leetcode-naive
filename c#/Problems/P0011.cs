using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/container-with-most-water/ 	
  ///    Submission: https://leetcode.com/submissions/detail/238060297/
  /// </summary>
  internal class P0011
  {
    public class Solution
    {
      public int MaxArea(int[] height)
      {
        var i = 0;
        var j = height.Length - 1;

        var area = 0;
        var maxArea = 0;

        while (i < j)
        {
          area = (j - i) * Math.Min(height[j], height[i]);
          if (maxArea < area)
            maxArea = area;

          if (height[i] < height[j])
            i++;
          else
            j--;
        }

        return maxArea;
      }
    }
  }
}
