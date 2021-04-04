using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-nice-pairs-in-an-array/
  ///    Submission: https://leetcode.com/submissions/detail/476312877/
  /// </summary>
  internal class P1814
  {
    public class Solution
    {
      public int CountNicePairs(int[] nums)
      {
        for (var i = 0; i < nums.Length; ++i)
          nums[i] = nums[i] - int.Parse(new string(nums[i].ToString().Reverse().ToArray()));

        var freq = new Dictionary<int, int>();
        var ans = 0;
        var mod = 1_000_000_007;

        for (var i = 0; i < nums.Length; ++i)
        {
          if (freq.ContainsKey(nums[i]))
          {
            ans += freq[nums[i]];
            ans %= mod;
          }

          if (freq.ContainsKey(nums[i]))
            freq[nums[i]]++;
          else
            freq[nums[i]] = 1;
        }

        return ans;
      }
    }
  }
}
