using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/out-of-boundary-paths/
  ///    Submission: https://leetcode.com/submissions/detail/421251037/
  /// </summary>
  internal class P0576
  {
    public class Solution
    {
      public int FindPaths(int m, int n, int N, int i, int j)
      {
        if (N == 0)
          return 0;

        var mod = (int)1e9 + 7;

        var dp = new Dictionary<(int i, int j), int>[N];
        dp[0] = new Dictionary<(int i, int j), int> { [(i, j)] = 1 };

        var paths = new Dictionary<(int i, int j), (List<(int i, int j)> ps, int oob)>();

        for (var x = 0; x < m; x++)
        {
          for (var y = 0; y < n; y++)
          {
            var pps = new List<(int i, int j)>();
            var oob = 0;

            var ps = new List<(int i, int j)>()
            {
              (x - 1, y),
              (x + 1, y),
              (x, y - 1),
              (x, y + 1),
            };

            foreach (var p in ps)
              if (p.i >= 0 && p.j >= 0 && p.i < m && p.j < n)
                pps.Add((p.i, p.j));
              else
                oob++;

            paths[(x, y)] = (pps, oob);
          }
        }

        for (var index = 1; index < N; index++)
        {
          dp[index] = new Dictionary<(int i, int j), int>();
          var keys = dp[index - 1].Keys.ToArray();

          foreach (var key in keys)
          {
            foreach (var path in paths[key].ps)
            {
              if (!dp[index].ContainsKey(path))
                dp[index][path] = 0;

              dp[index][path] += dp[index - 1][key];
              dp[index][path] %= mod;
            }
          }
        }

        var ans = 0L;

        for (var index = 0; index < N; index++)
        {
          var dict = dp[index];

          foreach (var entry in dict)
          {
            var oob = paths[entry.Key].oob;
            ans += oob * entry.Value;
          }
        }

        return (int)(ans % mod);
      }
    }
  }
}
