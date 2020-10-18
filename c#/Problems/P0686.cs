using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/repeated-string-match/
  ///    Submission: https://leetcode.com/submissions/detail/238079511/
  /// </summary>
  internal class P0686
  {
    public class Solution
    {
      public int RepeatedStringMatch(string A, string B)
      {
        var strA = new StringBuilder();
        var repeated = 0;

        if (A.Length < B.Length)
        {
          strA = new StringBuilder(string.Join("", Enumerable.Range(1, B.Length / A.Length).Select(_ => A)));
        }

        if (strA.ToString().IndexOf(B) != -1)
          return strA.Length / A.Length;

        while (repeated <= 2 || strA.Length <= B.Length)
        {
          strA.Append(A);
          if (strA.ToString().IndexOf(B) != -1)
            return strA.Length / A.Length;

          repeated++;
        }

        return -1;
      }
    }
  }
}
