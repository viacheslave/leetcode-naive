using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/arithmetic-slices/
  ///    Submission: https://leetcode.com/submissions/detail/404911996/
  /// </summary>
  internal class P0413
  {
    public class Solution
    {
      public int NumberOfArithmeticSlices(int[] A)
      {
        var dp = Enumerable.Range(1, A.Length)
            .Select(x => new Dictionary<int, int>())
            .ToList();

        for (var i = 2; i < A.Length; i++)
        {
          var res = new Dictionary<int, int>();

          foreach (var entry in dp[i - 1])
          {
            if (A[i] - A[i - 1] == entry.Key)
              res[entry.Key] = entry.Value;
          }

          if (A[i] - A[i - 1] == A[i - 1] - A[i - 2])
          {
            var key = A[i] - A[i - 1];

            if (!res.ContainsKey(key))
              res.Add(key, 0);

            res[key]++;
          }

          dp[i] = res;
        }

        return dp.Sum(x => x.Sum(f => f.Value));
      }
    }
  }
}
