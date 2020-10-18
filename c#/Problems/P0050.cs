using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/powx-n/
  ///    Submission: https://leetcode.com/submissions/detail/225745051/
  /// </summary>
  internal class P0050
  {
    public class Solution
    {
      public double MyPow(double x, int n)
      {
        if (n == 0)
          return 1d;

        var neg = (n < 0);

        if (neg)
          n = -n;

        var value = T(x, n, neg);

        if (!neg)
          return value;

        return 1 / value;
      }

      private double T(double x, int n, bool neg)
      {
        if (n == 1 || n == -1)
          return x;

        if (n % 2 != 0)
          return T(x * x, (n - 1) / 2, neg) * x;
        else
          return T(x * x, n / 2, neg);
      }
    }
  }
}
