using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/image-overlap/
  ///    Submission: https://leetcode.com/submissions/detail/391924652/
  /// </summary>
  internal class P0835
  {
    public class Solution
    {
      public int LargestOverlap(int[][] A, int[][] B)
      {
        int[][] aleft = new int[A.Length][];
        int[][] aright = new int[A.Length][];

        int[][] bleft = new int[B.Length][];
        int[][] bright = new int[B.Length][];

        ShiftedA(A, aleft, aright);
        ShiftedB(B, bleft, bright);

        var ans = 0;

        for (var vert = -A.Length + 1; vert < A.Length; vert++)
        {
          for (var horiz = -A.Length + 1; horiz < A.Length; horiz++)
          {
            var arange = (0, A.Length - 1);
            var brange = (0, A.Length - 1);

            if (vert < 0)
            {
              arange = (-vert, A.Length - 1);
              brange = (0, A.Length - 1 + vert);
            }
            else
            {
              brange = (vert, A.Length - 1);
              arange = (0, A.Length - 1 - vert);
            }

            var ashift = horiz < 0 ? aleft : aright;
            var bshift = horiz < 0 ? bright : bleft;

            var res = GetResult(arange, brange, ashift, bshift, Math.Abs(horiz));
            ans = Math.Max(ans, res);
          }
        }

        return ans;
      }

      private int GetResult((int, int) arange, (int, int) brange, int[][] ashift, int[][] bshift, int v)
      {
        var rowspan = arange.Item2 - arange.Item1 + 1;

        var sum = 0;

        for (var row = 0; row < rowspan; row++)
        {
          var arow = arange.Item1 + row;
          var brow = brange.Item1 + row;

          var left = ashift[arow][v];
          var right = bshift[brow][v];

          var and = left & right;

          while (and > 0)
          {
            sum += (and % 2 == 1) ? 1 : 0;
            and = and / 2;
          }
        }

        return sum;
      }

      private static void ShiftedA(int[][] A, int[][] aleft, int[][] aright)
      {
        for (var row = 0; row < A.Length; row++)
        {
          var value = 0;
          for (var col = 0; col < A.Length; col++)
          {
            value += A[row][col] * (int)Math.Pow(2, A.Length - col - 1);
          }

          aleft[row] = new int[A.Length];
          aright[row] = new int[A.Length];

          aleft[row][0] = value;
          aright[row][0] = value;

          for (var col = 0; col < A.Length; col++)
          {
            aleft[row][col] = (value << col) % (int)Math.Pow(2, A.Length);
            aright[row][col] = value >> col;
          }
        }
      }

      private static void ShiftedB(int[][] A, int[][] aleft, int[][] aright)
      {
        for (var row = 0; row < A.Length; row++)
        {
          var value = 0;
          for (var col = 0; col < A.Length; col++)
          {
            value += A[row][col] * (int)Math.Pow(2, A.Length - col - 1);
          }

          aleft[row] = new int[A.Length];
          aright[row] = new int[A.Length];

          aleft[row][0] = value;
          aright[row][0] = value;

          for (var col = 0; col < A.Length; col++)
          {
            aleft[row][col] = value;
            aright[row][col] = value;
          }
        }
      }
    }
  }
}
