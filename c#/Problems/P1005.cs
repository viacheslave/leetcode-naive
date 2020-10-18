using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximize-sum-of-array-after-k-negations/
  ///    Submission: https://leetcode.com/submissions/detail/244168643/
  /// </summary>
  internal class P1005
  {
    public class Solution
    {
      public int LargestSumAfterKNegations(int[] A, int K)
      {
        Array.Sort(A);

        for (int i = 0; i < A.Length; i++)
        {
          if (K > 0 && A[i] < 0)
          {
            A[i] = 0 - A[i];
            K--;
          }
        }

        if (K > 0)
        {
          if (K % 2 == 1)
          {
            return A.Sum() - 2 * A.Min();
          }
        }

        return A.Sum();
      }
    }
  }
}
