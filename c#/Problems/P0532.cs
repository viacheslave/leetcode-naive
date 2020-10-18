using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/k-diff-pairs-in-an-array/
  ///    Submission: https://leetcode.com/submissions/detail/234764847/
  /// </summary>
  internal class P0532
  {
    public class Solution
    {
      public int FindPairs(int[] nums, int k)
      {
        if (nums.Length <= 1)
          return 0;

        Array.Sort(nums);

        var hs = new HashSet<(int, int)>();

        for (var i = 0; i < nums.Length; i++)
        {
          for (var j = i + 1; j < nums.Length; j++)
          {
            if (nums[j] - nums[i] < k)
              continue;

            if (nums[j] - nums[i] == k)
            {
              hs.Add((nums[i], nums[j]));
              continue;
            }

            if (nums[j] - nums[i] > k)
              break;
          }
        }

        return hs.Count;
      }
    }
  }
}
