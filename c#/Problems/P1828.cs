using System;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/queries-on-number-of-points-inside-a-circle/
  ///    Submission: https://leetcode.com/submissions/detail/490782502/
  /// </summary>
  internal class P1828
  {
    public class Solution
    {
      public int[] CountPoints(int[][] points, int[][] queries)
      {
        var ans = new int[queries.Length];

        for (var i = 0; i < queries.Length; ++i)
        {
          foreach (var point in points)
          {
            var distance = Math.Sqrt(
              (queries[i][0] - point[0]) * (queries[i][0] - point[0]) +
              (queries[i][1] - point[1]) * (queries[i][1] - point[01]));

            if (distance <= queries[i][2])
              ans[i]++;
          }
        }

        return ans;
      }
    }
  }
}
