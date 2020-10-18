using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/largest-perimeter-triangle/
  ///    Submission: https://leetcode.com/submissions/detail/238024972/
  /// </summary>
  internal class P0976
  {
    public class Solution
    {
      public int LargestPerimeter(int[] A)
      {
        Array.Sort(A);
        Array.Reverse(A);

        for (var pi = 0; pi < A.Length - 2; pi++)
        {
          for (var pk = 2; pk < A.Length; pk++)
          {
            for (var pj = pi + 1; pj <= pk - 1; pj++)
            {
              if (A[pi] > A[pj] + A[pk])
              {
                break;
              }

              if (A[pi] < A[pj] + A[pk] &&
                  A[pj] < A[pi] + A[pk] &&
                  A[pk] < A[pj] + A[pi])
              {
                return A[pi] + A[pj] + A[pk];
              }
            }
          }
        }

        return 0;
      }
    }
  }
}
