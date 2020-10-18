using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/spiral-matrix-ii/
  ///    Submission: https://leetcode.com/submissions/detail/231135766/
  /// </summary>
  internal class P0059
  {
    public class Solution
    {
      public int[][] GenerateMatrix(int n)
      {
        var matrix = new int[n][];

        for (var i = 0; i < n; i++)
          matrix[i] = new int[n];

        matrix[0][0] = 1;

        var direction = 0;
        var x = 0;
        var y = 0;

        var xminBorder = -1;
        var yminBorder = -1;
        var xmaxBorder = matrix.Length;
        var ymaxBorder = matrix[0].Length;

        var num = 2;

        while (true)
        {
          // can move?
          var can =
              (direction % 4 == 0 && (y + 1) != ymaxBorder) ||
              (direction % 4 == 1 && (x + 1) != xmaxBorder) ||
              (direction % 4 == 2 && (y - 1) != yminBorder) ||
              (direction % 4 == 3 && (x - 1) != xminBorder);

          if (!can)
          {
            direction++;

            if (direction % 4 == 1)
              xminBorder++;
            if (direction % 4 == 2)
              ymaxBorder--;
            if (direction % 4 == 3)
              xmaxBorder--;
            if (direction % 4 == 0)
              yminBorder++;

            var can2 =
                (direction % 4 == 0 && (y + 1) != ymaxBorder) ||
                (direction % 4 == 1 && (x + 1) != xmaxBorder) ||
                (direction % 4 == 2 && (y - 1) != yminBorder) ||
                (direction % 4 == 3 && (x - 1) != xminBorder);

            if (!can2)
              break;
          }

          // move
          if (direction % 4 == 0)
            y++;

          if (direction % 4 == 1)
            x++;

          if (direction % 4 == 2)
            y--;

          if (direction % 4 == 3)
            x--;

          matrix[x][y] = num++;
        }

        return matrix;
      }
    }
  }
}
