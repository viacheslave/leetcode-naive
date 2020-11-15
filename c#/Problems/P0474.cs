using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/ones-and-zeroes/
  ///    Submission: https://leetcode.com/submissions/detail/420623209/
  /// </summary>
  internal class P0474
  {
    public class Solution
    {
      public int FindMaxForm(string[] strs, int m, int n)
      {
        var values = new (int m, int n)[strs.Length];

        for (var i = 0; i < strs.Length; i++)
        {
          var zeros = strs[i].Count(x => x == '0');
          var ones = strs[i].Count(x => x == '1');

          values[i] = (zeros, ones);
        }

        var dp = new Dictionary<(int m, int n), int>();

        for (var i = 0; i < strs.Length; i++)
        {
          var set = new Dictionary<(int m, int n), int>();

          foreach (var key in dp.Keys.ToArray())
          {
            if (values[i].m + key.m <= m && values[i].n + key.n <= n)
            {
              var updated = (values[i].m + key.m, values[i].n + key.n);

              set[updated] = set.ContainsKey(updated)
                ? Math.Max(set[updated], dp[key] + 1)
                : dp[key] + 1;
            }
          }

          var self = (values[i].m, values[i].n);
          if (self.m <= m && self.n <= n)
          {
            set[self] = set.ContainsKey(self)
              ? Math.Max(dp[self], 1)
              : 1;
          }

          foreach (var entry in set)
          {
            dp[entry.Key] = dp.ContainsKey(entry.Key)
              ? Math.Max(dp[entry.Key], entry.Value)
              : entry.Value;
          }
        }

        return dp.Count > 0 ? dp.Max(c => c.Value) : 0;
      }
    }
  }
}
