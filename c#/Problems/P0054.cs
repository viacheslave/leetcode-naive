using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/spiral-matrix/
  ///    Submission: https://leetcode.com/submissions/detail/231134817/
  /// </summary>
  internal class P0054
  {
    public class Solution
    {
      public IList<int> SpiralOrder(int[][] matrix)
      {
        if (matrix.Length == 0 || matrix[0].Length == 0)
          return new List<int>();

        var list = new List<int>() { matrix[0][0] };

        var direction = 0;
        var x = 0;
        var y = 0;

        var xminBorder = -1;
        var yminBorder = -1;
        var xmaxBorder = matrix.Length;
        var ymaxBorder = matrix[0].Length;

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

          list.Add(matrix[x][y]);

        }

        return list;
      }
    }
  }
}
