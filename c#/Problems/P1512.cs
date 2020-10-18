using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-good-pairs/
  ///    Submission: https://leetcode.com/submissions/detail/387705800/
  /// </summary>
  internal class P1512
  {
    public class Solution
    {
      public int NumIdenticalPairs(int[] nums)
      {
        var ans = 0;

        for (var i = 0; i < nums.Length - 1; i++)
          for (var j = i + 1; j < nums.Length; j++)
            if (nums[i] == nums[j])
              ans++;

        return ans;
      }
    }
  }
}
