using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/image-smoother/
  ///    Submission: https://leetcode.com/submissions/detail/234763100/
  /// </summary>
  internal class P0661
  {
    public class Solution
    {
      public int[][] ImageSmoother(int[][] M)
      {
        var rows = M.Length;
        var cols = M[0].Length;

        var res = new int[rows][];

        for (var i = 0; i < M.Length; i++)
        {
          res[i] = new int[M[i].Length];

          for (var j = 0; j < M[i].Length; j++)
            res[i][j] = Get(M, i, j, rows, cols);

        }

        return res;
      }

      public int Get(int[][] M, int i, int j, int rows, int cols)
      {
        var ind = new List<(int, int)>
        {
            (i,j),

            (i-1, j),
            (i-1, j+1),
            (i  , j+1),
            (i+1, j+1),
            (i+1, j),
            (i+1, j-1),
            (i,   j-1),
            (i-1, j-1)
        };

        var sum = 0;
        var count = 0;

        foreach (var (r, c) in ind)
        {
          if (Valid(r, c, rows, cols))
          {
            sum += M[r][c];
            count += 1;
          }
        }

        return (int)Math.Floor(1.0 * sum / count);
      }

      public bool Valid(int r, int c, int rows, int cols)
      {
        return r >= 0
            && r < rows
            && c >= 0
            && c < cols;
      }
    }
  }
}
