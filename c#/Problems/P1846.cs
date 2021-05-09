using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-element-after-decreasing-and-rearranging/
  ///    Submission: https://leetcode.com/submissions/detail/490851630/
  /// </summary>
  internal class P1846
  {
    public class Solution
    {
      public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
      {
        Array.Sort(arr);

        if (arr[0] != 1)
          arr[0] = 1;

        for (var i = 1; i < arr.Length; ++i)
        {
          if (Math.Abs(arr[i] - arr[i - 1]) > 1)
            arr[i] = arr[i - 1] + 1;
        }

        return arr[^1];
      }
    }
  }
}
