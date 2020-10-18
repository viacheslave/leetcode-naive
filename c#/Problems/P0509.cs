using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/fibonacci-number/
  ///    Submission: https://leetcode.com/submissions/detail/226899242/
  /// </summary>
  internal class P0509
  {
    public class Solution
    {
      Dictionary<int, int> fib = new Dictionary<int, int>()
      {
          {1, 1},
          {2, 1},
          {3, 2}
      };

      public int Fib(int N)
      {

        if (N == 0)
          return 0;

        for (var i = 4; i <= N; i++)
        {
          fib[i] = fib[i - 1] + fib[i - 2];
        }


        return fib[N];
      }
    }
  }
}
