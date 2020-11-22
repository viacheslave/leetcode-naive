using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/check-if-two-string-arrays-are-equivalent/
  ///    Submission: https://leetcode.com/submissions/detail/422930331/
  /// </summary>
  internal class P1662
  {
    public class Solution
    {
      public bool ArrayStringsAreEqual(string[] word1, string[] word2) =>
        word1.Aggregate(new StringBuilder(), (sb, w) => sb.Append(w)).ToString() ==
        word2.Aggregate(new StringBuilder(), (sb, w) => sb.Append(w)).ToString();
    }
  }
}
