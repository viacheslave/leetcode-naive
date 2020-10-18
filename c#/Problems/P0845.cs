using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-mountain-in-array/
  ///    Submission: https://leetcode.com/submissions/detail/243256947/
  /// </summary>
  internal class P0845
  {
    public class Solution
    {
      public int LongestMountain(int[] A)
      {
        var max = 0;

        for (int i = 1; i < A.Length - 1; i++)
        {
          var left = i - 1;
          var right = i + 1;

          while (left >= 0 && A[left] < A[left + 1])
            left--;

          while (right < A.Length && A[right] < A[right - 1])
            right++;

          if (left == i - 1 || right == i + 1)
            continue;

          max = Math.Max(max, right - left - 1);
        }

        return max;
      }
    }
  }
}
