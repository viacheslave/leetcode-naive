using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/best-sightseeing-pair/
  ///    Submission: https://leetcode.com/submissions/detail/428200063/
  /// </summary>
  internal class P1014
  {
    public class Solution
    {
      public int MaxScoreSightseeingPair(int[] A)
      {
        var left = 0;
        var arr = new List<(int left, int right)>();

        for (var i = 1; i < A.Length; i++)
        {
          left = Math.Max(left, A[i - 1] + (i - 1));
          arr.Add((left, A[i] - i));
        }

        return arr.Max(x => x.left + x.right);
      }
    }
  }
}
