using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/unique-paths-ii/
  ///    Submission: https://leetcode.com/submissions/detail/237608324/
  /// </summary>
  internal class P0063
  {
    public class Solution
    {
      public int UniquePathsWithObstacles(int[][] obstacleGrid)
      {
        var m = obstacleGrid.Length;
        var n = obstacleGrid[0].Length;

        var map = new Dictionary<(int, int), int?>();
        return Count(map, obstacleGrid, 0, 0, m, n);
      }

      private int Count(Dictionary<(int, int), int?> map, int[][] obstacleGrid, int mi, int ni, int m, int n)
      {
        if (mi == m || ni == n)
          return 0;

        if (obstacleGrid[mi][ni] == 1)
          return 0;

        if (mi == m - 1 && ni == n - 1)
          return 1;


        map.TryGetValue((mi + 1, ni), out var s1);
        if (s1 == null)
        {
          s1 = Count(map, obstacleGrid, mi + 1, ni, m, n);
          map[(mi + 1, ni)] = s1.Value;
        }

        map.TryGetValue((mi, ni + 1), out var s2);
        if (s2 == null)
        {
          s2 = Count(map, obstacleGrid, mi, ni + 1, m, n);
          map[(mi, ni + 1)] = s2.Value;
        }

        return s1.Value + s2.Value;
      }
    }
  }
}
