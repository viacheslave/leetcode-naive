using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/rotate-image/
  ///    Submission: https://leetcode.com/submissions/detail/226133858/
  /// </summary>
  internal class P0048
  {
    public class Solution
    {
      private struct Point
      {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
          X = x;
          Y = y;
        }
      }

      public void Rotate(int[][] matrix)
      {


        for (var x = 0; x < matrix.Length / 2; x++)
        {
          for (var y = x; y < matrix.Length - (x + 1); y++)
          {
            SwapCircle(matrix, x, y);
          }
        }

      }

      private void SwapCircle(int[][] matrix, int x, int y)
      {
        var length = matrix.Length - 1;

        Point current = new Point(x, y);
        Point next = GetNext(current.X, current.Y, length);
        Swap(matrix, current, next);

        current = next;
        next = GetNext(current.X, current.Y, length);
        Swap(matrix, current, next);

        current = next;
        next = GetNext(current.X, current.Y, length);
        Swap(matrix, current, next);
      }

      private void Swap(int[][] matrix, Point current, Point next)
      {
        var currentValue = matrix[current.X][current.Y];
        var nextValue = matrix[next.X][next.Y];

        matrix[current.X][current.Y] = nextValue;
        matrix[next.X][next.Y] = currentValue;
      }

      private Point GetNext(int x, int y, int length)
      {
        return new Point(length - y, x);
      }
    }
  }
}
