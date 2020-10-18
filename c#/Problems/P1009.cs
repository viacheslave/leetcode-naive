using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/complement-of-base-10-integer/
  ///    Submission: https://leetcode.com/submissions/detail/231264208/
  /// </summary>
  internal class P1009
  {
    public class Solution
    {
      public int BitwiseComplement(int N)
      {
        if (N == 0)
          return 1;

        var original = N;
        var power = 0;
        var comp = 0;

        while (true)
        {
          if (power == 31)
            break;

          if (original >= (int)Math.Pow(2, power))
          {
            var digit = N % 2;

            if (digit == 0)
              comp += (int)Math.Pow(2, power);

            N = N >> 1;
            power++;
            continue;
          }
          break;
        }

        return comp;
      }
    }
  }
}
