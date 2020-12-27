using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/where-will-the-ball-fall/
  ///    Submission: https://leetcode.com/submissions/detail/435250219/
  /// </summary>
  internal class P1706
  {
    public class Solution
    {
      public int[] FindBall(int[][] grid)
      {
        var rows = grid.Length;
        var cols = grid[0].Length;

        var ans = new int[cols];

        // save output col if the ball falls through
        var memo = new Dictionary<(int i, int j, int p), int>();

        for (var j = 0; j < cols; j++)
        {
          var path = new List<(int i, int j, int part)>();

          var row = 0;
          var col = j;
          var part = 1;

          path.Add((0, j, 1));

          while (true)
          {
            // check if we already visited the path
            if (memo.ContainsKey((row, col, part)))
            {
              row = rows - 1;
              col = memo[(row, col, part)];
              part = 0;
              break;
            }

            // fall out
            if (row == rows - 1 && part == 0)
              break;

            if (part == 1)
            {
              // part = 1 - on the top of the cell

              // walls or V shape
              if (grid[row][col] == 1)
              {
                if (col + 1 >= cols || grid[row][col + 1] == -1)
                  break;
              }

              if (grid[row][col] == -1)
              {
                if (col - 1 < 0 || grid[row][col - 1] == 1)
                  break;
              }

              part = 0;
              col += grid[row][col];
            }
            else
            {
              // part = 0 - on the bottom of the cell

              part = 1;
              row++;
            }

            path.Add((row, col, part));
          }

          ans[j] = (row == rows - 1 && part == 0) ? col : -1;

          // save successful path
          if (ans[j] != -1)
          {
            foreach (var p in path)
              memo.Add(p, col);
          }
        }

        return ans;
      }
    }
  }
}
