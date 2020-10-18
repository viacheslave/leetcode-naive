using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/reverse-bits/
  ///    Submission: https://leetcode.com/submissions/detail/227854873/
  /// </summary>
  internal class P0190
  {
    public class Solution
    {
      public uint reverseBits(uint n)
      {
        var i = 32;
        uint res = 0;

        while (i > 0)
        {
          var set = n % 2 == 1;
          n = n >> 1;

          if (set) res += (uint)Math.Pow(2, i - 1);
          i--;
        }

        return res;
      }
    }
  }
}
