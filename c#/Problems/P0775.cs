using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/global-and-local-inversions/
  ///    Submission: https://leetcode.com/submissions/detail/396144451/
  /// </summary>
  internal class P0775
  {
    public class Solution
    {
      public bool IsIdealPermutation(int[] A)
      {
        var sl = new SortedList<int, int>();

        var glob = 0;
        var local = 0;

        for (int i = A.Length - 1; i >= 0; i--)
        {
          sl.Add(A[i], 0);
          glob += sl.IndexOfKey(A[i]);
        }

        for (int i = A.Length - 1; i > 0; i--)
        {
          if (A[i - 1] > A[i])
            local++;
        }

        return glob == local;
      }
    }
  }
}
