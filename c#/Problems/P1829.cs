using System;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-xor-for-each-query/
  ///    Submission: https://leetcode.com/submissions/detail/490843992/
  /// </summary>
  internal class P1829
  {
    public class Solution
    {
      public int[] GetMaximumXor(int[] nums, int maximumBit)
      {
        var ans = new int[nums.Length];
        var max = (int)Math.Pow(2, maximumBit) - 1;

        var xor = 0;
        for (var i = 0; i < nums.Length; ++i)
        {
          xor = xor ^ nums[i];
          ans[i] = xor ^ max;
        }

        Array.Reverse(ans);
        return ans;
      }
    }
  }
}
