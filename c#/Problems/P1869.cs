using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longer-contiguous-segments-of-ones-than-zeros/
  ///    Submission: https://leetcode.com/submissions/detail/497201231/
  /// </summary>
  internal class P1869
  {
    public class Solution
    {
      public bool CheckZeroOnes(string s)
      {
        var ones = s.Replace('0', ' ');
        var zeroes = s.Replace('1', ' ');

        var longestOnes = ones.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var longestZeroes = zeroes.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var l1 = longestOnes.Length == 0 ? 0 : longestOnes.Max(x => x.Length);
        var l0 = longestZeroes.Length == 0 ? 0 : longestZeroes.Max(x => x.Length);

        return l1 > l0;
      }
    }
  }
}
