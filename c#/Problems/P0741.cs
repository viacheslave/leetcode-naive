using System;
using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/cherry-pickup/
  ///    Submission: https://leetcode.com/submissions/detail/432359795/
  /// </summary>
  internal class P0741
  {
    public class Solution
    {
      public int CherryPickup(int[][] grid)
      {
        var len = grid.Length;

        if (grid[0][0] == -1 || grid[len - 1][len - 1] == -1)
          return 0;

        var dp = new int[len, len, len, len];

        // let's imagine that we travel not to n-1, n-1 and back, but 
        // only forward, twice, simultaneously

        // 0 - forward x
        // 1 = forward y
        // 2 - back x
        // 3 - back y
        dp[0, 0, 0, 0] = grid[0][0];


        // i - iteration
        for (var i = 1; i < len * 2; i++)
        {
          var min = i - len + 1;
          if (min < 0) min = 0;

          // (ax, ay, bx, by) - state that reflect a pair of cells in the grid 
          for (int ax = min, ay = i - min; ay >= min; ax++, ay--)
          {
            for (int bx = min, by = i - min; by >= min; bx++, by--)
            {
              // if any cell is blocked - the state is invalid, mark it and skip
              if (grid[ax][ay] == -1 || grid[bx][by] == -1)
              {
                dp[ax, ay, bx, by] = -1;
                continue;
              }

              // possible prev states, max is 4, from up and left
              var prev = new List<(int, int, int, int)>
              {
                (ax - 1, ay, bx - 1, by),
                (ax - 1, ay, bx, by - 1),
                (ax, ay - 1, bx - 1, by),
                (ax, ay - 1, bx, by - 1),
              };

              var max = -1;

              foreach (var p in prev)
              {
                if (p.Item1 >= 0 && p.Item2 >= 0 && p.Item3 >= 0 && p.Item4 >= 0)
                {
                  // if prev state is not valid, we don't consider it
                  if (dp[p.Item1, p.Item2, p.Item3, p.Item4] == -1)
                    continue;

                  // if this is the same cell for both forward paths, count it once
                  max = (ax == bx && ay == by)
                    ? Math.Max(max, dp[p.Item1, p.Item2, p.Item3, p.Item4] + grid[ax][ay])
                    : Math.Max(max, dp[p.Item1, p.Item2, p.Item3, p.Item4] + grid[ax][ay] + grid[bx][by]);
                }
              }

              dp[ax, ay, bx, by] = max;
            }
          }
        }

        return Math.Max(dp[len - 1, len - 1, len - 1, len - 1], 0);
      }
    }
  }
}
