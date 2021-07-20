using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/build-array-from-permutation/
  ///    Submission: https://leetcode.com/submissions/detail/525482732/
  /// </summary>
  internal class P1920
  {
    public class Solution
    {
      public int[] BuildArray(int[] nums)
      {
        var ans = new int[nums.Length];

        for (var i = 0; i < nums.Length; i++)
          ans[i] = nums[nums[i]];

        return ans;
      }
    }
  }
}
