using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/binary-trees-with-factors/
  ///    Submission: https://leetcode.com/submissions/detail/467211035/
  /// </summary>
  internal class P0823
  {
    public class Solution
    {
      public int NumFactoredBinaryTrees(int[] A)
      {
        Array.Sort(A);
        var map = A.Select((a, i) => (a, i)).ToDictionary(_ => _.a, _ => _.i);
        var dp = Enumerable.Repeat(1L, A.Length).ToArray();

        for (var i = 0; i < A.Length; i++)
        {
          for (var j = 0; j < i; j++)
          {
            var root = A[i];
            var left = A[j];

            if (root % left == 0 && map.ContainsKey(root / left))
            {
              var right = root / left;
              var il = dp[map[left]];
              var ir = dp[map[right]];

              dp[map[root]] += il * ir;
            }
          }
        }

        var ans = 0L;
        for (var i = 0; i < A.Length; i++)
          ans += dp[i];

        var mod = 1_000_000_007;
        return (int)(ans % mod);
      }
    }
  }
}
