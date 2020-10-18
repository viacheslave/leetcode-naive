using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/hamming-distance/
  ///    Submission: https://leetcode.com/submissions/detail/228907516/
  /// </summary>
  internal class P0461
  {
    public class Solution
    {
      public int HammingDistance(int x, int y)
      {
        var ch1 = GetBinary(x);
        var ch2 = GetBinary(y);

        var result = 0;

        for (var i = 0; i < 31; i++)
        {
          var res = ch1[i] ^ ch2[i];
          if (res == 1)
            result++;
        }

        return result;
      }

      private int[] GetBinary(int num)
      {
        var ch = new int[31];

        for (var i = 0; i < 31; i++)
        {
          ch[i] = num % 2;
          num = num >> 1;
        }

        return ch;
      }
    }
  }
}
