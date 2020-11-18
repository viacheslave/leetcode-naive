using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/bitwise-ors-of-subarrays/
  ///    Submission: https://leetcode.com/submissions/detail/421594160/
  /// </summary>
  internal class P0898
  {
    public class Solution
    {
      public int SubarrayBitwiseORs(int[] A)
      {
        var dp = new HashSet<int>[A.Length];
        dp[0] = new HashSet<int>() { A[0] };

        for (var i = 1; i < A.Length; ++i)
        {
          dp[i] = new HashSet<int>() { A[i] };

          foreach (var entry in dp[i - 1])
            dp[i].Add(entry | A[i]);
        }

        return dp.SelectMany(d => d).Distinct().Count();
      }
    }
  }
}
