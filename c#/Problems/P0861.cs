using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/score-after-flipping-matrix/
  ///    Submission: https://leetcode.com/submissions/detail/239789855/
  /// </summary>
  internal class P0861
  {
    public class Solution
    {
      public int MatrixScore(int[][] A)
      {
        for (int i = 0; i < A.Length; i++)
        {
          if (A[i][0] == 0)
            FlipRow(A, i);
        }

        for (int j = 1; j < A[0].Length; j++)
        {
          var sum = 0;
          for (var i = 0; i < A.Length; i++)
            sum += A[i][j];

          if (sum <= A.Length / 2)
            FlipCol(A, j);
        }

        var gs = 0;
        for (int i = 0; i < A.Length; i++)
        {
          var gss = 0;
          for (var j = 0; j < A[i].Length; j++)
          {
            if (A[i][j] == 1)
            {
              gss += (int)Math.Pow(2, A[i].Length - 1 - j);
            }
          }

          gs += gss;
        }

        return gs;
      }

      private void FlipCol(int[][] a, int j)
      {
        for (int i = 0; i < a.Length; i++)
          a[i][j] = 1 - a[i][j];
      }

      private void FlipRow(int[][] a, int i)
      {
        for (int j = 0; j < a[i].Length; j++)
          a[i][j] = 1 - a[i][j];
      }
    }
  }
}
