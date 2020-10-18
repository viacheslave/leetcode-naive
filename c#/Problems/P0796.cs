using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/rotate-string/
  ///    Submission: https://leetcode.com/submissions/detail/231088126/
  /// </summary>
  internal class P0796
  {
    public class Solution
    {
      public bool RotateString(string A, string B)
      {
        if (A.Length != B.Length)
          return false;

        if (A.Length == 0)
          return true;

        if (A.Length == 1)
          return true;



        var sb = new StringBuilder(A);

        for (var i = 0; i < A.Length; i++)
        {
          Shift(sb);
          if (sb.ToString() == B)
            return true;
        }

        return false;
      }

      void Shift(StringBuilder sb)
      {
        var z = sb[0];

        for (var i = 1; i < sb.Length; i++)
          sb[i - 1] = sb[i];

        sb[sb.Length - 1] = z;
      }
    }
  }
}
