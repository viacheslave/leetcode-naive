using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/concatenation-of-array/
  ///    Submission: https://leetcode.com/submissions/detail/525480252/
  /// </summary>
  internal class P1929
  {
    public class Solution
    {
      public int[] GetConcatenation(int[] nums)
      {
        return new[] { nums, nums }.SelectMany(_ => _).ToArray();
      }
    }
  }
}
