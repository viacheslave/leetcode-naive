using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element/
  ///    Submission: https://leetcode.com/submissions/detail/378434112/
  /// </summary>
  internal class P1493
  {
    public class Solution
    {
      public int LongestSubarray(int[] nums)
      {
        if (nums.Length == 1)
          return 0;

        var start = 0;
        var sets = new List<(int, int)>();

        // get intervals
        for (var i = 1; i < nums.Length; i++)
        {
          if (i == 1)
          {
            if (nums[i - 1] == 1 && nums[i] == 1)
              start = 0;

            if (nums[i - 1] == 1 && nums[i] == 0)
              sets.Add((0, 0));

            if (nums[i - 1] == 0 && nums[i] == 1)
              start = 1;

            continue;
          }

          if (nums[i] == 1 && nums[i - 1] == 0)
            start = i;

          if (nums[i] == 0 && nums[i - 1] == 1)
            sets.Add((start, i - 1));

          if (i == nums.Length - 1 && nums[i] == 1)
            sets.Add((start, i));
        }

        // check intervals with one zero between

        if (sets.Count == 0)
          return 0;

        if (sets.Count == 1)
        {
          if (sets[0].Item1 == 0 && sets[0].Item2 == nums.Length - 1)
            return nums.Length - 1;
          else
            return sets[0].Item2 - sets[0].Item1 + 1;
        }

        var candidate = int.MinValue;

        for (var i = 0; i < sets.Count - 1; i++)
        {
          if (sets[i].Item2 + 2 == sets[i + 1].Item1)
          {
            candidate = Math.Max(candidate, sets[i + 1].Item2 - sets[i].Item1);
          }
        }

        var maxItem = sets.Max(x => x.Item2 - x.Item1 + 1);

        if (candidate == int.MinValue)
          return maxItem;

        return Math.Max(maxItem, candidate);
      }
    }
  }
}
