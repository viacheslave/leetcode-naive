using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/can-make-arithmetic-progression-from-sequence/
  ///    Submission: https://leetcode.com/submissions/detail/387137627/
  /// </summary>
  internal class P1502
  {
    public class Solution
    {
      public bool CanMakeArithmeticProgression(int[] arr)
      {
        Array.Sort(arr);

        var diffs = new List<int>();
        for (var i = 1; i < arr.Length; i++)
        {
          diffs.Add(arr[i] - arr[i - 1]);
        }

        return diffs.Distinct().Count() == 1;
      }
    }
  }
}
