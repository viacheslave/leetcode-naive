using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/sum-of-two-integers/
  ///    Submission: https://leetcode.com/submissions/detail/241423547/
  /// </summary>
  internal class P0371
  {
    public class Solution
    {
      public int GetSum(int a, int b)
      {
        var abits = GetBits(a);
        var bbits = GetBits(b);

        var added = Add(abits, bbits);
        var result = GetValue(added);

        return result;
      }

      private int GetValue(int[] added)
      {
        var neg = added[0] == 1;
        if (neg)
        {
          var minusone = new int[32];
          for (int i = 0; i < 32; i++)
            minusone[i] = 1;

          added = Add(added, minusone);

          for (int i = 0; i < 32; i++)
            added[i] = 1 - added[i];
        }

        var value = 0;
        for (int i = 31; i > 0; i--)
        {
          if (added[i] == 1)
            value += (int)Math.Pow(2, 31 - i);
        }

        if (neg)
          return (-1) * value;

        return value;
      }

      private int[] Add(int[] abits, int[] bbits)
      {
        var res = new int[32];

        int carry = 0;
        for (int i = 31; i >= 0; i--)
        {
          var value = abits[i] + bbits[i] + carry;
          res[i] = value % 2;
          carry = (value >= 2) ? 1 : 0;
        }

        return res;
      }

      private int[] GetBits(int s)
      {
        if (s == int.MinValue)
        {
          var min = new int[32];
          min[0] = 1;
          return min;
        }

        var neg = false;
        if (s < 0)
        {
          neg = true;
          s = s * (-1);
        }

        var res = new int[32];

        var index = 31;
        while (s > 0)
        {
          var digit = (s % 2 == 1) ? 1 : 0;
          res[index] = digit;

          index--;
          s >>= 1;
        }

        if (neg)
        {
          for (int i = 0; i < 32; i++)
            res[i] = 1 - res[i];

          var one = new int[32];
          one[31] = 1;

          res = Add(res, one);
        }

        return res;
      }
    }
  }
}
