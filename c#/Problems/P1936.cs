using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/add-minimum-number-of-rungs/
  ///    Submission: https://leetcode.com/submissions/detail/524604811/
  /// </summary>
  internal class P1936
  {
    public class Solution
    {
      public int AddRungs(int[] rungs, int dist)
      {
        return Enumerable
          .Range(0, rungs.Length)
          .Select(i => i == 0 ? rungs[i] : (rungs[i] - rungs[i - 1]))
          .Select(d => d <= dist ? 0 : ((d - 1) / dist))
          .Sum();
      }
    }
  }
}
