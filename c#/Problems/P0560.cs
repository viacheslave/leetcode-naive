using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/subarray-sum-equals-k/
  ///    Submission: https://leetcode.com/submissions/detail/247601868/
  /// </summary>
  internal class P0560
  {
    public class Solution
    {
      public int SubarraySum(int[] nums, int k)
      {
        var prefixSum = new int[nums.Length];
        var hs = new Dictionary<int, List<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
          var value = i == 0
               ? nums[0]
               : prefixSum[i - 1] + nums[i];

          if (!hs.ContainsKey(value))
            hs[value] = new List<int>();

          hs[value].Add(i);
          prefixSum[i] = value;
        }

        var ans = 0;

        for (int i = 0; i < prefixSum.Length; i++)
        {
          if (prefixSum[i] == k)
            ans++;

          var target = prefixSum[i] - k;
          if (hs.TryGetValue(target, out var indexList))
          {
            ans += indexList.Count(_ => _ < i);
          }
        }

        return ans;
      }
    }
  }
}
