﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/total-hamming-distance/
  ///    Submission: https://leetcode.com/submissions/detail/426151601/
  /// </summary>
  internal class P0477
  {
    public class Solution
    {
      public int TotalHammingDistance(int[] nums)
      {
        var ans = 0;

        var counts = new int[31][];
        for (var i = 0; i < counts.Length; i++)
          counts[i] = new int[nums.Length];

        for (var i = 0; i < nums.Length; i++)
          for (var pow = 0; pow <= 31; pow++)
            if ((nums[i] & (1 << pow)) == (1 << pow))
              counts[pow][i] = 1;

        for (var c = 0; c < counts.Length; c++)
        {
          var ones = counts[c].Count(_ => _ == 1);
          ans += ones * (counts[c].Length - ones);
        }

        return ans;
      }
    }
  }
}
