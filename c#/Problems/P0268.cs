using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/missing-number/
  ///    Submission: https://leetcode.com/submissions/detail/228676678/
  /// </summary>
  internal class P0268
  {
    public class Solution
    {
      public int MissingNumber(int[] nums)
      {
        var sum = 0;
        for (var i = 0; i < nums.Length; i++)
          sum += nums[i];

        var expected = (nums.Length + 1) * (nums.Length) / 2;

        return expected - sum;
      }
    }
  }
}
