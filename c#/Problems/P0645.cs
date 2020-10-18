using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/set-mismatch/
  ///    Submission: https://leetcode.com/submissions/detail/229914634/
  /// </summary>
  internal class P0645
  {
    public class Solution
    {
      public int[] FindErrorNums(int[] nums)
      {
        if (nums.Length < 2)
          return new int[0];

        var expSum = (nums.Length * (nums.Length + 1)) / 2;

        var sum = 0;
        var hs = new HashSet<int>();
        var dup = 0;

        foreach (var s in nums)
        {
          sum += s;
          if (hs.Contains(s))
          {
            dup = s;
          }
          else
          {
            hs.Add(s);
          }
        }

        var diff = expSum - sum;

        return new int[] { dup, dup + diff };
      }
    }
  }
}
