using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/check-if-a-string-contains-all-binary-codes-of-size-k/
  ///    Submission: https://leetcode.com/submissions/detail/387732235/
  /// </summary>
  internal class P1461
  {
    public class Solution
    {
      public bool HasAllCodes(string s, int k)
      {
        var codes = new HashSet<string>();

        for (int i = 0; i < s.Length - k + 1; i++)
        {
          var code = s.Substring(i, k);
          if (!codes.Contains(code))
            codes.Add(code);
        }

        return codes.Count == Math.Pow(2, k);
      }
    }
  }
}
