using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/subarray-sums-divisible-by-k/
  ///    Submission: https://leetcode.com/submissions/detail/425328152/
  /// </summary>
  internal class P0974
  {
    public class Solution
    {
      public int SubarraysDivByK(int[] A, int K)
      {
        var ans = 0;

        var pre = new int[A.Length + 1];
        for (var i = 0; i < A.Length; ++i)
          pre[i + 1] = (pre[i] + A[i] + K * 10000) % K;

        var pos = new Dictionary<int, int>();
        pos[pre[0]] = 1;

        for (var i = 0; i < A.Length; ++i)
        {
          if (!pos.ContainsKey(pre[i + 1]))
            pos[pre[i + 1]] = 0;

          pos[pre[i + 1]]++;
        }

        foreach (var p in pos)
          ans += ((p.Value - 1) * p.Value) / 2;

        return ans;
      }
    }
  }
}
