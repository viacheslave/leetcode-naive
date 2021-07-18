using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-good-numbers/
  ///    Submission: https://leetcode.com/submissions/detail/519433569/
  /// </summary>
  internal class P1922
  {
    public class Solution
    {
      private const int _mod = (int)1e9 + 7;

      public int CountGoodNumbers(long n)
      {
        var ans = ExpMod(20, n / 2);

        return n % 2 == 0
          ? (int)(ans % _mod)
          : (int)((1L * ans * 5) % _mod);
      }

      private long ExpMod(long b, long exp)
      {
        var ans = 1L;
        b %= _mod;

        while (exp > 0)
        {
          if (exp % 2 == 1)
            ans = (ans * b) % _mod;

          exp >>= 1;
          b = (b * b) % _mod;
        }

        return ans;
      }
    }
  }
}
