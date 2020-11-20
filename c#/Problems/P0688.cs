using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/knight-probability-in-chessboard/
  ///    Submission: https://leetcode.com/submissions/detail/422391141/
  /// </summary>
  internal class P0688
  {
    public class Solution
    {
      public double KnightProbability(int N, int K, int r, int c)
      {
        var dp = new double[N, N];

        dp[r, c] = 1;

        var ans = 0d;

        for (var step = 0; step < K; ++step)
        {
          var t = new double[N, N];

          for (var i = 0; i < N; ++i)
          {
            for (var j = 0; j < N; ++j)
            {
              if (dp[i, j] == 0)
                continue;

              var paths = new List<(int i, int j)>()
              {
                (i - 2, j - 1),
                (i - 2, j + 1),
                (i - 1, j - 2),
                (i - 1, j + 2),
                (i + 1, j - 2),
                (i + 1, j + 2),
                (i + 2, j - 1),
                (i + 2, j + 1),
              };

              foreach (var p in paths)
              {
                if (p.i >= 0 && p.j >= 0 && p.i < N && p.j < N)
                  t[p.i, p.j] += dp[i, j] * 0.125;
                else
                  ans += dp[i, j] * 0.125;
              }
            }
          }

          dp = t;
        }

        return 1 - ans;
      }
    }
  }
}
