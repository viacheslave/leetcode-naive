using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/valid-mountain-array/
  ///    Submission: https://leetcode.com/submissions/detail/230690630/
  /// </summary>
  internal class P0941
  {
    public class Solution
    {
      public bool ValidMountainArray(int[] A)
      {
        if (A.Length < 3)
          return false;

        var up = true;

        for (var i = 1; i < A.Length; i++)
        {
          if (A[i] == A[i - 1])
            return false;

          if (up)
          {
            if (A[i] > A[i - 1])
              continue;

            if (i == 1)
              return false;

            else
              up = false;

            continue;
          }
          else
          {
            if (A[i] < A[i - 1])
              continue;
            else
              return false;
          }

        }

        if (up)
          return false;

        return true;
      }
    }
  }
}
